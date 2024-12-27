using HospitalBookingSystem.Domain.Model.Appointment;

namespace HospitalBookingSystem.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly AppointmentService _appointmentService;

    public AppointmentController(AppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    #region GetAppointmentListAsync

    [HttpGet]
    public async Task<IActionResult> GetAppointmentListAsync()
    {
        try
        {
            var lst = await _appointmentService.GetAppointmentListAsync();
            return Ok(lst);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    #endregion

    #region GetAppointmentListByDateAsync

    [HttpGet("{date}")]
    public async Task<IActionResult> GetAppointmentListByDateAsync(DateTime date)
    {
        try
        {
            var lst = await _appointmentService.GetAppointmentListByDateAsync(date);
            return Ok(lst);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    #endregion

    #region CreateAppointmentAsync

    [HttpPost]
    public async Task<IActionResult> CreateAppointmentAsync([FromForm]AppointmentModel appointment)
    {
        var item = _appointmentService.CreateAppointmentAsync(appointment);
        return Ok(item);
    }

    #endregion
}
