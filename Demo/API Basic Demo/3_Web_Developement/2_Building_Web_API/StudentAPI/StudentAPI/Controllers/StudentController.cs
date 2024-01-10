using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentAPI.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("/")]
        public IHttpActionResult GetStudentData()
        {
            return Ok("Initial Method invoked");
        }
    }
}
