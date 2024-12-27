namespace HospitalBookingSystem.Domain.Features.Doctor;

public class DoctorService
{
    private readonly AppDbContext _appDbContext;

    public DoctorService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #region GetDoctorAsync

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

    #endregion

    #region GetDoctorByNameAsync

    public async Task<Result<List<DoctorRequestModel>>> GetDoctorByNameAsync(string name)
    {
        Result<List<DoctorRequestModel>> result;

        try
        {
            var doctor = _appDbContext.TblDoctors
                .Where(x => x.Name == name)
                .AsNoTracking();

            if (doctor is null)
            {
                result = Result<List<DoctorRequestModel>>.ValidationError("No Doctor Found");
            }
           
            var lst = await doctor.Select(x => new DoctorRequestModel()
            {
                Name = x.Name,
                Specialization = x.Specialization,
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

    #endregion

    #region CreateDoctorAsync

    public async Task<Result<DoctorModel>> CreateDoctorAsync(DoctorModel doctorModel)
    {
        Result<DoctorModel> result;

        try
        {
            #region Validation

            if (doctorModel is null)
            {
                result = Result<DoctorModel>.ValidationError("Please fill all field.");
            }
            if (string.IsNullOrEmpty(doctorModel.Name))
            {
                result = Result<DoctorModel>.ValidationError("Please fill Doctor Name");
            }
            if (string.IsNullOrEmpty(doctorModel.Specialization))
            {
                result = Result<DoctorModel>.ValidationError("Please fill Specialization");
            }
            if(string.IsNullOrEmpty(doctorModel.PhoneNumber))
            {
                result = Result<DoctorModel>.ValidationError("Please fill Phone Number");
            }
            if (string.IsNullOrEmpty(doctorModel.Email))
            {
                result = Result<DoctorModel>.ValidationError("Please fill Email");
            }
            if(string.IsNullOrEmpty(doctorModel.Address))
            {
                result = Result<DoctorModel>.ValidationError("Please fill Address");
            }

            #endregion

            var doctorId = Guid.NewGuid().ToString();

            var doctor = new TblDoctor
            {
                DoctorId = doctorId,
                Name = doctorModel.Name,
                Specialization = doctorModel.Specialization,
                PhoneNumber = doctorModel.PhoneNumber,
                Email = doctorModel.Email,
                Address = doctorModel.Address,
            };

            _appDbContext.TblDoctors.Add(doctor);
            await _appDbContext.SaveChangesAsync();

            result = Result<DoctorModel>.Success(doctorModel);

        }
        catch(Exception ex)
        {
            result = Result<DoctorModel>.SystemError(ex.Message);
        }
        return result;
    }

    #endregion

    public async Task<Result<DoctorResponseModel>> UpdateDoctorAsync(string name, DoctorResponseModel responseModel)
    {
        Result<DoctorResponseModel> result;

        try
        {
            var doctor = _appDbContext.TblDoctors
                .AsNoTracking()
                .FirstOrDefault(x => x.Name == name);

            if(doctor is null)
            {
                result = Result<DoctorResponseModel>.ValidationError("Doctor does not exist.");
            }

            if(!string.IsNullOrEmpty(responseModel.Specialization))
            {
                doctor.Specialization = responseModel.Specialization;
            }

            if (!string.IsNullOrEmpty(responseModel.PhoneNumber))
            {
                doctor.PhoneNumber = responseModel.PhoneNumber;
            }

            if (!string.IsNullOrEmpty(responseModel.Address))
            {
                doctor.Address = responseModel.Address;
            }

            _appDbContext.TblDoctors.Attach(doctor);
            _appDbContext.Entry(doctor).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

            result = Result<DoctorResponseModel>.Success(responseModel);
        }
        catch (Exception ex)
        {
            result = Result<DoctorResponseModel>.SystemError(ex.Message);
        }
        return result;
    }

}
