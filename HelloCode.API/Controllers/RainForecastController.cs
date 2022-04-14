using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HelloCode.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RainForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public RainForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public String Get()
        {
            return("Hello from your rain forecast controller");
        }
    }
}
