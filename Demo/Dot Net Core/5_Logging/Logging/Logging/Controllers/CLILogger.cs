using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    /// <summary>
    /// Demonstrates Logging functionality 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLILogger : ControllerBase
    {
        #region Private Members 

        private readonly ILogger<CLILogger> _logger;

        #endregion

        #region Public Members

        /// <summary>
        /// Constructor injection of ILogger<T>
        /// </summary>
        /// <param name="logger"></param>
        public CLILogger(ILogger<CLILogger> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Log information into console 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LogInfoInConsole")]
        public IActionResult LogInfoInConsole()
        {
            _logger.LogInformation("This is an information message");

            _logger.LogWarning("This is a warning message");

            _logger.LogError("This is an error message");

            return Ok("Information logged successfully .. ");
        }

        #endregion
    }
}
