using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace _19ConsoleToWebApplication.Controllers
{
    /// <summary>
    /// As per url, webpage returns the content.
    /// </summary>
    [ApiController]
    [Route("test/[action]")]
    public class TestController : ControllerBase
    {
        #region Controllers 
        public string Get()
        {
            return "Hello from Get";
        }

        public string Get1()
        {
            return "Hello from Get1";
        }

        #endregion
    }
}
