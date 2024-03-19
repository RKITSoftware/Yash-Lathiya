using _3_Filters.Filter;
using _3_Filters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _3_Filters.Controllers
{
    /// <summary>
    /// Login Controller which generates and authorizes user by token & authorizeFilter
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLLoginController : ControllerBase
    {
        /// <summary>
        /// Generates jwt token with username claim
        /// </summary>
        /// <param name="objLoginDTO"> username & password</param>
        /// <returns> jwt token </returns>
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDTO objLoginDTO)
        {
            try
            {
                // if username or password is blank 
                if(objLoginDTO.Username == null || objLoginDTO.Password == null)
                {
                    return BadRequest("Username and/or password not specified");
                }
                // If username & password are correct
                if(objLoginDTO.Username.Equals("yash") && objLoginDTO.Password.Equals("MyPassword"))
                {
                    var secretKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes("thisisasecretkey@123"));
                    var signinCredentials = new SigningCredentials (secretKey, SecurityAlgorithms.HmacSha256);
                    var claims = new List<Claim>
                    {
                        new Claim("username", objLoginDTO.Username)
                    };
                    var jwtSecurityToken = new JwtSecurityToken(
                        issuer: "MyDotNetCoreApplication",
                        audience: "https://localhost:44384/",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials
                    );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
                }
            }
            catch
            {
                return BadRequest("An error occured while generationg jwt token");
            }
            return Unauthorized();
        }

        /// <summary>
        /// This method uses authorization filter to check user's accessibility
        /// </summary>
        /// <returns> Authorized Message </returns>
        [HttpGet]
        [ServiceFilter(typeof(MyAuthorizationFilter))]
        [Route("testAuthorizarion")]
        public IActionResult TestAuthorization()
        {
            return Ok("Authorized");
        }
    }
}
