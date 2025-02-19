﻿namespace HospitalBookingSystem.Domain.Features.Patient;

public class PatientService
{
    private readonly AppDbContext _appDbContext;

    public PatientService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    #region GetPatientAsyn

    public async Task<Result<List<PatientRequestModel>>> GetPatientAsyn()
    {
        Result<List<PatientRequestModel>> response;

        try
        {
            var patient = _appDbContext.TblPatients.AsNoTracking();

            if (patient is null)
            {
                return Result<List<PatientRequestModel>>.ValidationError("No Patient Found");
            }

            var lst = await patient.Select(x => new PatientRequestModel()
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

            response =  Result<List<PatientRequestModel>>.Success(lst); 
        }
        catch (Exception ex)
        {
            response =  Result<List<PatientRequestModel>>.SystemError(ex.Message);
        }
        return response;
    }

    #endregion

    #region GetPatientByNameAsyn

    public async Task<Result<List<PatientRequestModel>>> GetPatientByNameAsyn(string name)
    {
        Result<List<PatientRequestModel>> response;

        try
        {
            var patient = _appDbContext.TblPatients
                .Where(x => x.Name == name)
                .AsNoTracking();
                

            if (patient is null)
            {
                return Result<List<PatientRequestModel>>.ValidationError("No Patient Found");
            }

            var item  = await patient.Select(x => new PatientRequestModel()
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

            response = Result<List<PatientRequestModel>>.Success(item);
        }
        catch (Exception ex)
        {
            response = Result<List<PatientRequestModel>>.SystemError(ex.Message);
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

            if (requestModel is null)
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

            var patientId = Guid.NewGuid().ToString();

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

    #region UpatePatientAsync

    public async Task<Result<PatientResponseModel>>UpatePatientAsync(string name , PatientResponseModel responseModel)
    {
        Result<PatientResponseModel> result;
        try
        {
            var patient = await _appDbContext.TblPatients
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Name == name);

            if (patient is null)
            {
                result = Result<PatientResponseModel>.ValidationError("Patient does not exist");
            }

            #region Validation

            if (!string.IsNullOrEmpty(responseModel.PhoneNumber))
            {
                patient.PhoneNumber = responseModel.PhoneNumber;
            }
            if (!string.IsNullOrEmpty(responseModel.Address))
            {
                patient.Address = responseModel.Address;
            }
            if (!string.IsNullOrEmpty(responseModel.MedicalHistory))
            {
                patient.MedicalHistory = responseModel.MedicalHistory;
            }
            if (!string.IsNullOrWhiteSpace(responseModel.EmergencyContact))
            {
                patient.EmergencyContact = responseModel.EmergencyContact;
            }

            #endregion

            _appDbContext.TblPatients.Attach(patient);
            _appDbContext.Entry(patient).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();
            result = Result<PatientResponseModel>.Success(responseModel);
        }
        catch (Exception ex)
        {
            result = Result<PatientResponseModel>.SystemError(ex.Message);
        }

        return result;
    }

    #endregion

}
