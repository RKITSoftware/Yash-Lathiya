using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _5_Action_Methods.Controllers
{
    /// <summary>
    /// Demonstrates approx all action method results 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLActionMethods : ControllerBase
    {
        #region Public Methods

        /// <summary>
        /// Useful for client side javascript
        /// </summary>
        /// <returns> json data </returns>
        [HttpGet]
        [Route("JsonResult")]
        public IActionResult GetJsonData()
        {
            return Ok(new
            {
                key1 = "value1",
                key2 = "value2"
            });
        }

        /// <summary>
        /// Demonstrates redirect action method result
        /// </summary>
        /// <returns> redirects to google.com </returns>
        [HttpGet]
        [Route("RedirectToGoogle")]
        public IActionResult RedirectToGoogle()
        {
            return Redirect("https://www.google.com/");
        }

        /// <summary>
        /// Demonstrates Content action method result
        /// </summary>
        /// <returns> returns plain text content </returns>
        [HttpGet]
        [Route("TextContent")]
        public IActionResult TextContent()
        {
            return Content("This is plain text", "text/plain");
        }

        /// <summary>
        /// Demonstrates File action method result
        /// </summary>
        /// <returns> returns plain text content </returns>
        [HttpGet]
        [Route("DownloadFile")]
        public IActionResult DownloadFile()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes("C:\\Users\\yash.l\\source\\repos\\Yash-Lathiya\\Demo\\Dot Net Core\\2_Asp_dotNet_Core_Requesting_Processing_Pipeline\\RequestProcessingPipeline\\5_Action_Methods\\Files\\5_C#_Advance.pdf");

            return File(fileBytes, "application/pdf", "C_Sharp_Advance_Doc.pdf");   
        }
        
        /// <summary>
        /// We can directly return different status code as result
        /// </summary>
        /// <returns> different status codes </returns>
        [HttpGet]
        [Route("HttpStatusCodes")]
        public IActionResult HttpStatusCodes()
        {
            return NotFound(); // status code - 404
        }

        /// <summary>
        /// Demonstrates usecase of ActionResult class
        /// </summary>
        /// <returns>  </returns>
        [HttpGet]
        [Route("FromActionResultClass")]
        public ActionResult FromActionResultClass()
        {
            return Unauthorized(); 
        }

        #endregion
    }
}
