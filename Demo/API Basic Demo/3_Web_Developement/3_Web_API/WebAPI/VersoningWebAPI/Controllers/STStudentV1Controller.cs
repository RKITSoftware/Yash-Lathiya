using Microsoft.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VersoningWebAPI.Models;

namespace VersoningWebAPI.Controllers
{
    /// <summary>
    /// Version 1 Controller
    /// </summary>
    public class STStudentV1Controller : ApiController
    {
        // List of Studdent's objects
        // Static bcz it should not initialize every time method runs.

        static List<Student1> lstStudent1;

        // Static constructor which adds initial data to the list
        static STStudentV1Controller()
        {
            lstStudent1 = new List<Student1>();
            lstStudent1.Add(new Student1() { u01f01 = 1001, u01f02 = "Sachin Tendulkar", u01f03 = "Computer", u01f04 = DateTime.Today });
            lstStudent1.Add(new Student1() { u01f01 = 1002, u01f02 = "Mahendra Singh Dhoni", u01f03 = "Computer", u01f04 = DateTime.Today });
            lstStudent1.Add(new Student1() { u01f01 = 1003, u01f02 = "Virat Kohli", u01f03 = "Chemical", u01f04 = DateTime.Today });
            lstStudent1.Add(new Student1() { u01f01 = 1004, u01f02 = "Suresh Raina", u01f03 = "Mechanical", u01f04 = DateTime.Today });
        }

        /// <summary>
        ///     GET : /api/student
        ///     To get deatils of all students
        /// </summary>
        /// <returns> 
        ///     List of all studnet1 as per version 1 
        /// </returns>
        [HttpGet]
        public IHttpActionResult GetStudent()
        {
            return Ok(lstStudent1);  //status code 200
        }
    }
}
