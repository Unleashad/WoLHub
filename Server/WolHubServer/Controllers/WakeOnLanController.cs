using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WolHubServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WakeOnLanController : ControllerBase
    {

        private readonly ILogger<WakeOnLanController> _logger;

        public WakeOnLanController(ILogger<WakeOnLanController> logger) { 
            _logger = logger;
        }

        [HttpGet(Name = "PruebaApi")]
        public string Get()
        {
            return "prueba";
        }
    }
}
