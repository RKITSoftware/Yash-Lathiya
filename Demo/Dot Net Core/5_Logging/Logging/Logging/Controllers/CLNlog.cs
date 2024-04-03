using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers
{
    /// <summary>
    /// Demonstrates use of nLog
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLNlog : ControllerBase
    {
        #region  Private Members 

        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        #endregion

        #region Public Members

        /// <summary>
        /// Log information into console 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LogInfoInConsoleAndFile")]
        public IActionResult LogInfoInConsole()
        {
            _logger.Info("This is an information message");

            _logger.Warn("This is a warning message");

            _logger.Error("This is an error message");

            return Ok("Information logged successfully .. ");
        }

        #endregion
    }
}
