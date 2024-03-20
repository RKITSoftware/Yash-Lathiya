using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2_Routing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CLRouting : ControllerBase
    {
        [HttpGet]
        [Route("Greetings")]
        public IActionResult Greeting(string name)
        {
            return Ok("Hello World + " + name);
        }


    }
}
