namespace HospitalBookingSystem.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly PatientService _service;

    public PatientController(PatientService service)
    {
        _service = service;
    }

    #region GetPatientAsync

    [HttpGet]
    public async Task<IActionResult> GetPatientAsync()
    {
        try
        {
            var lst = await _service.GetPatientAsyn();
            return Ok(lst);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    #endregion

    #region CreatePatientAsync

    [HttpPost]
    public async Task<IActionResult> CreatePatientAsync([FromForm]PatientRequestModel requestModel)
    {
        try
        {
            var item = await _service.CreatePatientAsync(requestModel);
            return Ok(item);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    #endregion

}
