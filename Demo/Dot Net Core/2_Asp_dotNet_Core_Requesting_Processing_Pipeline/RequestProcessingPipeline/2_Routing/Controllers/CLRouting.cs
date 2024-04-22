using Microsoft.AspNetCore.Mvc;

namespace _2_Routing.Controllers
{
    /// <summary>
    /// Demonstrates the implementation of routing 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLRouting : ControllerBase
    {
        #region Public Methods

        /// <summary>
        /// Custom Routing url
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Greetings")]
        public IActionResult Greeting(string name)
        {
            return Ok("Hello World + " + name);
        }

        #endregion
    }
}
