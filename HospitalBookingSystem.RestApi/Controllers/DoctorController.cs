namespace HospitalBookingSystem.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly DoctorService _service;

    public DoctorController(DoctorService service)
    {
        _service = service;
    }

    #region GetDoctorAsync

    [HttpGet]
    public async Task<IActionResult> GetDoctorAsync()
    {
        var lst = await _service.GetDoctorAsync();
        return Ok(lst);
    }

    #endregion

    #region GetDoctorByNameAsync

    [HttpGet("{name}")]
    public async Task<IActionResult> GetDoctorByNameAsync(string name)
    {
        var item = await _service.GetDoctorByNameAsync(name);
        return Ok(item);
    }

    #endregion

    #region CreateDoctorAsync

    [HttpPost]
    public async Task<IActionResult> CreateDoctorAsync([FromForm]DoctorModel doctorModel)
    {
        var item = await _service.CreateDoctorAsync(doctorModel);
        return Ok(item);
    }

    #endregion

    #region UpdateDoctorAsync

    [HttpPatch]
    public async Task<IActionResult>UpdateDoctorAsync(string name, DoctorResponseModel responseModel)
    {
        var item = await _service.UpdateDoctorAsync(name, responseModel);
        return Ok(item);
    }

    #endregion

    [HttpPut]
    public async Task<IActionResult> DisadvaliableDoctorAsync(string name)
    {
        var item = await _service.DisadvaliableDoctorAsync(name);
        return Ok(item);
    }

}
