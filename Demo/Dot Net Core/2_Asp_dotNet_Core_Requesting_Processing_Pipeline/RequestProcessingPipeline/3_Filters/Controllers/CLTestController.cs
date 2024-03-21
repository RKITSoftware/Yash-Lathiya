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

        /// <summary>
        /// Adds header name: sachin_tendulkar in response header
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ResponseHeader")]
        [MyResponseHeaderFilter("Name", "Sachin Tendulkar")]
        public IActionResult ResponseHeader()
        {
            return Ok("Response header added");
        }

        /// <summary>
        /// Check particular header is present in request header or not
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CheckRequestHeader")]
        [MyHeaderResourceFilter("userId")] // Apply the custom resource filter to this action method
        public IActionResult Get()

        {
            // If the custom header is present, return a success response
            return Ok("UserID header is present in request header");
        }

        /// <summary>
        /// Tests exception filters
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("TestsExceptionFilter")]
        [ServiceFilter(typeof(ExceptionFilter))] 
        public IActionResult TestsExceptionFilter()
        {
            int i =  0;
            int k = 5 / i;
            return Ok("Exceeption Filter");
        }

        /// <summary>
        /// Demonstrates implementation of Async Filter
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AsyncFilter")]
        [ServiceFilter(typeof(AsyncStopwatchFilter))]
        [ServiceFilter(typeof(AsyncConsoleFilter))]
        public IActionResult TestsAsyncFilter()
        {
            return Ok("Execution of async filter is printed in console");
        }
    }

}

