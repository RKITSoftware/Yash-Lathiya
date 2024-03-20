using _1_Middleware.BL;
using _1_Middleware.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1_Middleware.Controllers
{
    /// <summary>
    /// Login controller which demonstrates usecase of middleware 1
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLLogin : ControllerBase
    {
        /// <summary>
        /// Find userid from redis cache
        /// </summary>
        /// <returns> userid from cache</returns>
        [HttpPost]
        [Route("GetUserId")]
        public IActionResult GetUserid()
        {
            BLRedis _objBLRedis = new BLRedis();
            var cachedValue = _objBLRedis.RetrieveFromCache("userId");

            if (cachedValue != null)
            {
                return Ok("userId : " + cachedValue);
            }

            return BadRequest("UserId not found");
        }

        /// <summary>
        /// Checkin credential 
        /// if credential is correct then it adds userId in redis cache
        /// </summary>
        /// <param name="objLoginDTO"> consists emailId & password </param>
        /// <returns> Login Message </returns>
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO objLoginDTO)
        {
            return Ok("Login Successfull ");
        }
    }
}
