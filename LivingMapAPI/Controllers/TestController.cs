using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LivingMapAPI.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : Controller
    {
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("1")]
        public IActionResult Test()
        {
            return Content(_configuration["Movies:ServiceApiKey"]);
        }
    }
}
