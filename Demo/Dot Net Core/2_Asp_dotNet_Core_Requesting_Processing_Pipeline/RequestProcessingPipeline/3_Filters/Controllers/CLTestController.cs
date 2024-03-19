using _3_Filters.Filter;
using Microsoft.AspNetCore.Mvc;

namespace _3_Filters.Controllers
{
    /// <summary>
    /// Test controller whiich checks execution of custom filter
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLTestController : ControllerBase
    {
        /// <summary>
        /// Executes custom filter here 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("test")]
        [ServiceFilter(typeof(MyCustomFilter))]
        public IActionResult Test()
        {
            // This action method will use the MyCustomFilter
            return Ok("Test endpoint with custom filter");
        }

    }

}

