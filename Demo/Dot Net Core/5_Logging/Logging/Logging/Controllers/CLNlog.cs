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
        #region Private Members 

        #region Static Members

        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        #endregion

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

            _logger.Debug("This is a debug message");

            _logger.Fatal("This is a fatal message");

            _logger.Log(NLog.LogLevel.Error, "Logged Error Message");

            return Ok("Information logged successfully .. ");
        }

        #endregion
    }
}
