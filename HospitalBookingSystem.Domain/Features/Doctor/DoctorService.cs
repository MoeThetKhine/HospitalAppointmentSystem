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

}
