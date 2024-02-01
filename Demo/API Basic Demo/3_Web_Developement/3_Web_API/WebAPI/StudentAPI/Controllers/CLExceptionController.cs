using StudentAPI.ExceptionHandling;
using StudentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentAPI.Controllers
{
    /// <summary>
    /// Demonstrates all exception methods
    /// </summary>
    public class CLExceptionController : ApiController
    {
        #region Model Data Insertion

        // List of Studdent's objects
        // Static bcz it should not initialize every time method runs.

        static List<Stu01> lstStudent;

        // Static constructor which adds initial data to the list
        static CLExceptionController()
        {
            lstStudent = new List<Stu01>();
            lstStudent.Add(new Stu01() { u01f01 = 1001, u01f02 = "Sachin Tendulkar", u01f03 = "Computer", u01f04 = DateTime.Today });
            lstStudent.Add(new Stu01() { u01f01 = 1002, u01f02 = "Mahendra Singh Dhoni", u01f03 = "Electrical", u01f04 = DateTime.Today });
            lstStudent.Add(new Stu01() { u01f01 = 1003, u01f02 = "Virat Kohli", u01f03 = "Chemical", u01f04 = DateTime.Today });
            lstStudent.Add(new Stu01() { u01f01 = 1004, u01f02 = "Suresh Raina", u01f03 = "Mechanical", u01f04 = DateTime.Today });
        }

        #endregion

        #region Public Methods

        // HttpResponceException

        /// <summary>
        ///     GET : api/exception/{enrollment}
        ///     To get details of particular student
        ///     If student enrollment is not found then it prints the customized message that " There is no student in the database with the enrollment : {enrollment}"
        /// </summary>
        /// <param name="enrollment"> Enrollment (u01f01) of the student object which we want to get</param>
        /// <returns> Details of particular student object with that enrollment id </returns>
        [HttpGet]
        [Route("api/exception/{enrollment}")]
        public IHttpActionResult GetStudent(int enrollment)
        {
            Stu01 currentStudent = lstStudent.FirstOrDefault(student => student.u01f01 == enrollment);

            if (currentStudent == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent($"There is no student in the database with the enrollment : {enrollment}"),
                    ReasonPhrase = "Enrollment not found"
                };

                throw new HttpResponseException(response);
            }
            else
            {
                return Ok(currentStudent); //status code 200 
            }
        }

        // Exception Filter

        /// <summary>
        ///     GET : api/exception/
        ///     To get details of all students
        ///     It should return Not Implemented Exception
        /// </summary>
        /// <param name="enrollment"> Enrollment (u01f01) of the student object which we want to get</param>
        /// <returns> Details of all objects of the stuents </returns>
        [HttpGet]
        [Route("api/exception/")]
        [NotImplementedExceptionFilter]  // this can be implemented on Controller as well as globally too ..
        public IHttpActionResult GetStudent()
        {
            throw new NotImplementedException( "This method is not implemented");
        }

        // HttpError

        /// <summary>
        ///     GET : api/exceptionHttpError/{enrollment}
        ///     To get details of particular student
        ///     If student enrollment is not found then it prints the customized message that " There is no student in the database with the enrollment : {enrollment}"
        /// </summary>
        /// <param name="enrollment"> Enrollment (u01f01) of the student object which we want to get</param>
        /// <returns> Details of particular student object with that enrollment id </returns>
        [HttpGet]
        [Route("api/exceptionHttpError/{enrollment}")]
        public HttpResponseMessage GetStudentHttpError(int enrollment)
        {
            Stu01 currentStudent = lstStudent.FirstOrDefault(student => student.u01f01 == enrollment);

            if (currentStudent == null)
            {
                var message = String.Format($"There is no student in the database with the enrollment : {enrollment}");
                return (Request.CreateErrorResponse(HttpStatusCode.NotFound, message));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK); //status code 200 
            }
        }

        #endregion
    }
}
