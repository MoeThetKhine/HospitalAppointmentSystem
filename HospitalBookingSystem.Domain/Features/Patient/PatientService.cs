using HospitalBookingSystem.Database.Models;
using HospitalBookingSystem.Domain.Model.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBookingSystem.Domain.Features.Patient
{
    public class PatientService
    {
        private readonly AppDbContext _appDbContext;

        public PatientService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<List<PatientModel>>> GetPatientAsyn()
        {
            Result<List<PatientModel>> response;

            try
            {
                var patient = _appDbContext.Patients.AsNoTracking();

                if (patient is null)
                {
                    return Result<List<PatientModel>>.ValidationError("No Patient Found");
                }

                var lst = await patient.Select(x => new PatientModel()
                {
                    PatientId = x.PatientId,
                    Name = x.Name,
                    DateOfBirth = x.DateOfBirth,
                    Gender = x.Gender,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Address = x.Address,
                    MedicalHistory = x.MedicalHistory,
                    EmergencyContact = x.EmergencyContact,
                    InsuranceDetails = x.InsuranceDetails
                }).ToListAsync();

                return Result<List<PatientModel>>.Success(lst); 
            }
            catch (Exception ex)
            {
                return Result<List<PatientModel>>.SystemError(ex.Message);
            }
        }
    }
}
