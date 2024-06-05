using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Controllers
{
    /// <summary>
    /// Test controller which shows exception handling
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLTest : ControllerBase
    {
        #region Public Methods

        /// <summary>
        /// Devide by zero exception 
        /// </summary>
        /// <returns> exception </returns>
        [HttpGet]
        [Route("TestException")]
        public IActionResult TestException()
        {
            int a = 5;
            int b = 0;
            return Ok(a / b);
        }

        #endregion

    }
}
