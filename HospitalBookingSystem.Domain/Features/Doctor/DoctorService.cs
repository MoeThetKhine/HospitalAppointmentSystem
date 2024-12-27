﻿using HospitalBookingSystem.Domain.Model.Doctor;
using System.Collections.Generic;

namespace HospitalBookingSystem.Domain.Features.Doctor
{
    public class DoctorService
    {
        private readonly AppDbContext _appDbContext;

        public DoctorService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Result<List<DoctorRequestModel>>> GetDoctorAsync()
        {
            Result<List<DoctorRequestModel>> result;

            try
            {
                var doctor = _appDbContext.TblDoctors.AsNoTracking();

                if(doctor is null)
                {
                    result = Result<List<DoctorRequestModel>>.ValidationError("No Doctor Found");
                }

                var lst = await doctor.Select(x => new DoctorRequestModel()
                {
                    Name = x.Name,
                    Specialization =x.Specialization,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    Address = x.Address,
                }).ToListAsync();

                result = Result<List<DoctorRequestModel>>.Success(lst);
            }
            catch (Exception ex)
            {
                result = Result<List<DoctorRequestModel>>.SystemError(ex.Message);
            }
            return result;
        }
    }
}
