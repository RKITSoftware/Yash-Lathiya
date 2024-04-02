using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLTest : ControllerBase
    {
        [HttpGet]
        [Route("TestException")]
        public IActionResult TestException()
        {
            int a = 5;
            int b = 0;
            return Ok(a / b);
        }
    }
}
