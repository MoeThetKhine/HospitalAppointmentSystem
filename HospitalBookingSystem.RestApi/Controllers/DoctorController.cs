using HospitalBookingSystem.Domain.Features.Doctor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalBookingSystem.RestApi.Controllers
{
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
    }
}
