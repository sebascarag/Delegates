using Delegate.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Delegate.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetCitiesAsync();

            return Ok(data);
        }
    }
}
