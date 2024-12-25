namespace HospitalBookingSystem.Domain.Features.Patient;

public class PatientService
{
    private readonly AppDbContext _appDbContext;

    public PatientService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #region GetPatientAsyn

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

    #endregion

    #region CreatePatientAsync

    public async Task<Result<PatientModel>> CreatePatientAsync(PatientModel requestModel)
    {
        Result<PatientModel> response;

        try
        {
            #region Validation

            if (requestModel == null)
            {
                return Result<PatientModel>.ValidationError("Please fill all fields.");
            }

            if (string.IsNullOrWhiteSpace(requestModel.Name))
            {
                return Result<PatientModel>.ValidationError("Patient Name is required.");
            }

            if (requestModel.DateOfBirth == null)
            {
                return Result<PatientModel>.ValidationError("Date Of Birth is required.");
            }

            if (string.IsNullOrWhiteSpace(requestModel.Gender))
            {
                return Result<PatientModel>.ValidationError("Gender is required.");
            }

            if (string.IsNullOrWhiteSpace(requestModel.PhoneNumber))
            {
                return Result<PatientModel>.ValidationError("Phone Number is required.");
            }

            if (string.IsNullOrWhiteSpace(requestModel.Email))
            {
                return Result<PatientModel>.ValidationError("Email is required.");
            }

            if (string.IsNullOrWhiteSpace(requestModel.Address))
            {
                return Result<PatientModel>.ValidationError("Address is required.");
            }

            if (string.IsNullOrWhiteSpace(requestModel.MedicalHistory))
            {
                return Result<PatientModel>.ValidationError("Medical History is required.");
            }

            if (string.IsNullOrWhiteSpace(requestModel.EmergencyContact))
            {
                return Result<PatientModel>.ValidationError("Emergency Contact is required.");
            }

            if (string.IsNullOrWhiteSpace(requestModel.InsuranceDetails))
            {
                return Result<PatientModel>.ValidationError("Insurance Details are required.");
            }

            #endregion

            var patientId = Guid.NewGuid();

            var patient = new TblPatient
            {
                PatientId = patientId, 
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

            _appDbContext.TblPatients.Add(patient);
            await _appDbContext.SaveChangesAsync();

            response = Result<PatientModel>.Success(requestModel);
        }
        catch (Exception ex)
        {
            response = Result<PatientModel>.SystemError(ex.Message);
        }

        return response;
    }

    #endregion

}
