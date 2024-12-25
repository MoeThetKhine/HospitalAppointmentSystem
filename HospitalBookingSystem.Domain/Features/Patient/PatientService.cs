using HospitalBookingSystem.Database.Models;
using HospitalBookingSystem.Domain.Model.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
                var patient = _appDbContext.TblPatients.AsNoTracking();

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

                response =  Result<List<PatientModel>>.Success(lst); 
            }
            catch (Exception ex)
            {
                response =  Result<List<PatientModel>>.SystemError(ex.Message);
            }
            return response;
        }

        public async Task<Result<PatientRequestModel>> CreatePatientAsync(PatientRequestModel requestModel)
        {
            Result<PatientRequestModel> response;

            try
            {
                if(requestModel is null)
                {
                    response = Result<PatientRequestModel>.ValidationError("Please field all field");
                }
                if (requestModel.Name.IsNullOrEmpty())
                {
                    response = Result<PatientRequestModel>.ValidationError("Patient Name is required.");
                }
                if(requestModel.DateOfBirth == null)
                {
                    response = Result<PatientRequestModel>.ValidationError("Date Of Birth is required.");
                }
                if (requestModel.Gender.IsNullOrEmpty())
                {
                    response = Result<PatientRequestModel>.ValidationError("Gender is required.");
                }
                if (requestModel.PhoneNumber.IsNullOrEmpty())
                {
                    response = Result<PatientRequestModel>.ValidationError("Phone Number is required.");
                }
                if (requestModel.Email.IsNullOrEmpty())
                {
                    response = Result<PatientRequestModel>.ValidationError("Email is required");
                }
                if (requestModel.Address.IsNullOrEmpty())
                {
                    response = Result<PatientRequestModel>.ValidationError("Address is required");
                }
                if (requestModel.MedicalHistory.IsNullOrEmpty())
                {
                    response = Result<PatientRequestModel>.ValidationError("Medial History is required.");
                }
                if (requestModel.EmergencyContact.IsNullOrEmpty())
                {
                    response = Result<PatientRequestModel>.ValidationError("Emergeny Contat is required.");
                }
                if (requestModel.InsuranceDetails.IsNullOrEmpty())
                {
                    response = Result<PatientRequestModel>.ValidationError("Insurane Details is required.");
                }

                var patient = new TblPatient
                {
                    Name = requestModel.Name,
                    DateOfBirth = requestModel.DateOfBirth,
                    Gender = requestModel.Gender,
                    PhoneNumber = requestModel.PhoneNumber,
                    Email = requestModel.Email,
                    Address = requestModel.Address,
                    MedicalHistory = requestModel.MedicalHistory,
                    EmergencyContact = requestModel.EmergencyContact,
                    InsuranceDetails = requestModel.InsuranceDetails,
                };

                _appDbContext.TblPatients.AddAsync(patient);
                await _appDbContext.SaveChangesAsync();

                response = Result<PatientRequestModel>.Success(requestModel);
            }
            catch(Exception ex)
            {
                response = Result<PatientRequestModel>.SystemError(ex.Message);
            }
            return response;
        }
    }
}
