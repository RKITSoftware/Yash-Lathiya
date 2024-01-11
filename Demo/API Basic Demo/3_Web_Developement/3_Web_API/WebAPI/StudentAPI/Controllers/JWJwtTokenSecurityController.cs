using StudentAPI.Authentication;
using StudentAPI.JwtToken;
using StudentAPI.Models;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace StudentAPI.Controllers
{
    /// <summary>
    /// This implements functionality of jwt token.
    /// </summary>
    public class JWJwtTokenSecurityController : ApiController
    {
        // List of Studdent's objects
        // Static bcz it should not initialize every time method runs.

        static List<Student> lstStudent;

        // Static constructor which adds initial data to the list
        static JWJwtTokenSecurityController()
        {
            lstStudent = new List<Student>();
            lstStudent.Add(new Student() { u01f01 = 1001, u01f02 = "Sachin Tendulkar", u01f03 = "Computer", u01f04 = DateTime.Today });
            lstStudent.Add(new Student() { u01f01 = 1002, u01f02 = "Mahendra Singh Dhoni", u01f03 = "Computer", u01f04 = DateTime.Today });
            lstStudent.Add(new Student() { u01f01 = 1003, u01f02 = "Virat Kohli", u01f03 = "Chemical", u01f04 = DateTime.Today });
            lstStudent.Add(new Student() { u01f01 = 1004, u01f02 = "Suresh Raina", u01f03 = "Mechanical", u01f04 = DateTime.Today });
        }

        /// <summary>
        ///     GET : /api/student
        ///     To get jwt Token
        /// </summary>
        /// <returns> 
        ///     JWT Token which is valid for specified timeout
        /// </returns>
        [HttpGet]
        [Route("api/getJwtToken")]
        public IHttpActionResult GetJwtToken(string username, string password)
        {
            // If user is valid then generates jwt token
            if(IsValidUser(username, password))
            {
                var token = TokenManager.GenerateToken(username);
                return Ok(new { access_token = token } );
            }

            // Otherwise returns that user is unauthorized
            return Unauthorized();
        }

        /// <summary>
        /// Checks user is valid or not
        /// </summary>
        /// <param name="username"> Username </param>
        /// <param name="password"> PAssword </param>
        /// <returns></returns>
        public bool IsValidUser(string username, string password)
        {
            // Hard-Code Validation Implementation
            if(username == "jwt" && password == "jwt")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
