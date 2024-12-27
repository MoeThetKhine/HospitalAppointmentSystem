namespace HospitalBookingSystem.Domain.Features.Appointment;

public class AppointmentService
{
    private readonly AppDbContext _context;

    public AppointmentService(AppDbContext context)
    {
        _context = context;
    }

    #region GetAppointmentListAsync

    public async Task<Result<List<AppointmentRequestModel>>> GetAppointmentListAsync()
    {
        Result<List<AppointmentRequestModel>> result;

        try
        {
            var appointment = _context.TblAppointments
                .Where(x=> x.Status == "Scheduled")
                .AsNoTracking();

            if(appointment is null)
            {
                result = Result<List<AppointmentRequestModel>>.ValidationError("No Data Found");
            }

            var lst = await appointment.Select(x => new AppointmentRequestModel()
            {
                PatientId = x.PatientId,
                DoctorId = x.DoctorId,
                AppointmentDate =x.AppointmentDate,
                Reason = x.Reason,
                Status = x.Status,
            }).ToListAsync();

            result = Result<List<AppointmentRequestModel>>.Success(lst);
        }
        catch (Exception ex)
        {
            result = Result<List<AppointmentRequestModel>>.SystemError(ex.Message);
        }
        return result;
    }

    #endregion

    #region GetAppointmentListByDateAsync

    public async Task<Result<List<AppointmentRequestModel>>> GetAppointmentListByDateAsync(DateTime date)
    {
        Result<List<AppointmentRequestModel>> result;

        try
        {
            var appointment = _context.TblAppointments
                .Where(x=> x.AppointmentDate == date && x.Status == "Scheduled")
                .AsNoTracking();

            if (appointment is null)
            {
                result = Result<List<AppointmentRequestModel>>.ValidationError("No Data Found");
            }

            var lst = await appointment.Select(x => new AppointmentRequestModel()
            {
                PatientId = x.PatientId,
                DoctorId = x.DoctorId,
                AppointmentDate = x.AppointmentDate,
                Reason = x.Reason,
                Status = x.Status,
            }).ToListAsync();

            result = Result<List<AppointmentRequestModel>>.Success(lst);
        }
        catch (Exception ex)
        {
            result = Result<List<AppointmentRequestModel>>.SystemError(ex.Message);
        }
        return result;
    }

    #endregion

    #region CreateAppointmentAsync

    public async Task<Result<AppointmentModel>> CreateAppointmentAsync(AppointmentModel appointment)
    {
        Result<AppointmentModel> result;

        try
        {
            var patient = _context.TblPatients.FirstOrDefault(x => x.PatientId == appointment.PatientId);
            var doctor = _context.TblDoctors.FirstOrDefault(x => x.DoctorId ==  appointment.DoctorId);

            #region Validation

            if (appointment is null)
            {
                result = Result<AppointmentModel>.ValidationError("Please Fill All Field");
            }

            if (string.IsNullOrEmpty(appointment.PatientId))
            {
                result = Result<AppointmentModel>.ValidationError("Please fill Patient ID");
            }

            if (string.IsNullOrEmpty(appointment.DoctorId))
            {
                result = Result<AppointmentModel>.ValidationError("Please fill Doctor ID");
            }

            if (appointment.AppointmentDate == DateTime.MinValue)
            {
                result = Result<AppointmentModel>.ValidationError("Please fill Appointment Date.");
            }

            if(string.IsNullOrEmpty(appointment.Reason))
            {
                result = Result<AppointmentModel>.ValidationError("Please fill Reason.");
            }

            if(string.IsNullOrEmpty(appointment.Status))
            {
                result = Result<AppointmentModel>.ValidationError("Please fill Status.");
            }

            if(appointment.PatientId != patient.PatientId)
            {
                result = Result<AppointmentModel>.ValidationError("Patient ID is not exist.");
            }
            
            if(appointment.DoctorId != doctor.DoctorId)
            {
                result = Result<AppointmentModel>.ValidationError("Doctor ID is not exist.");
            }

            #endregion

            var appointmentId = Guid.NewGuid().ToString();

            var apt = new TblAppointment
            {
                AppointmentId = appointmentId,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                Reason = appointment.Reason,
                Status = appointment.Status,
            };

           _context.TblAppointments.Add(apt);
            await _context.SaveChangesAsync();

            result = Result<AppointmentModel>.Success(appointment);
        }
        catch(Exception ex)
        {
            result = Result<AppointmentModel>.SystemError(ex.Message);
        }
        return result;
    }

    #endregion

}
