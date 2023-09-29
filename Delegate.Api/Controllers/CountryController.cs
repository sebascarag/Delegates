using Delegate.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Delegate.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetCountriesAsync();

            return Ok(data);
        }
    }
}
