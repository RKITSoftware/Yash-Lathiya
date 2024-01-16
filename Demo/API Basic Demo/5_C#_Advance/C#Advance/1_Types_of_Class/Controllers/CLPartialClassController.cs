using _1_Types_of_Class.Class.Partial_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1_Types_of_Class.Controllers
{
    /// <summary>
    /// Demonstration of Partial Class
    /// Student & StudentEducation both are partial class of Student class
    /// </summary>
    public class CLPartialClassController : ApiController
    {
        /// <summary>
        /// Collects all details related to student stored in dfferent partial class
        /// </summary>
        /// <returns> returns all data related student </returns>
        [HttpGet]
        [Route("PartialClass/getStudentDetails")]
        public IHttpActionResult GetStudentDetails()
        {
            Student student = new Student();

            student.Id = 1001;
            student.Name = "Sachin Tendulkar";
            student.Address = "Mumbai, Maharashtra";

            return Ok(new
            {
                // Data in Person 
                StudentID = student.Id,
                Name = student.Name,
                Address = student.Address,
                // Data in PersonEducation
                University = student.GetUniversityName(),
                CGPA = student.GetCgpa()
            });
        }
    }
}
