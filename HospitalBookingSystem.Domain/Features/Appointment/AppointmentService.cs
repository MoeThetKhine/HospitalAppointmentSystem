using HospitalBookingSystem.Domain.Model.Appointment;

namespace HospitalBookingSystem.Domain.Features.Appointment
{
    public class AppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<List<AppointmentRequestModel>>> GetAppointmentListAsync()
        {
            Result<List<AppointmentRequestModel>> result;

            try
            {
                var appointment = _context.TblAppointments.AsNoTracking();

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
    }
}
