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
    [HttpGet]
    public async Task<IActionResult> GetDoctorAsync()
    {
        var lst = await _service.GetDoctorAsync();
        return Ok(lst);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetDoctorByNameAsync(string name)
    {
        var item = await _service.GetDoctorByNameAsync(name);
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDoctorAsync([FromForm]DoctorModel doctorModel)
    {
        var item = await _service.CreateDoctorAsync(doctorModel);
        return Ok(item);
    }
}
