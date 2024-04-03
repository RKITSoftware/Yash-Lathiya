using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Logging.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLILogger : ControllerBase
    {
        private readonly ILogger<CLILogger> _logger;

        public CLILogger(ILogger<CLILogger> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("LogInfoInConsole")]
        public IActionResult LogInfoInConsole()
        {
            _logger.LogInformation("This is an information message");

            _logger.LogWarning("This is a warning message");

            _logger.LogError("This is an error message");

            return Ok("Information logged successfully .. ");
        }
    }
}
