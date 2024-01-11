using StudentAPI.Authentication;
using StudentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace StudentAPI.Controllers
{
    /// <summary>
    /// Student Controller which manages all Http methods relates to student
    /// It will allow to access the host ony if user is authenticated ..
    /// </summary>
    [UserAuthenticationAttribute]
    public class CLStudentController : ApiController
    {
        // List of Studdent's objects
        // Static bcz it should not initialize every time method runs.

        static List<Student> lstStudent;
        
        // Static constructor which adds initial data to the list
        static CLStudentController() 
        { 
            lstStudent = new List<Student>();
            lstStudent.Add(new Student() {u01f01 = 1001, u01f02 = "Sachin Tendulkar", u01f03 = "Computer", u01f04 = DateTime.Today});
            lstStudent.Add(new Student() {u01f01 = 1002, u01f02 = "Mahendra Singh Dhoni", u01f03 = "Computer", u01f04 = DateTime.Today });
        }

        /// <summary>
        ///     GET : /api/student
        ///     To get deatils of all students
        ///     This functionality is only provided to the user whoose role is student
        /// </summary>
        /// <returns> 
        ///     List of all studnet in json format
        /// </returns>
        [UserAuthorizationAttribute(Roles = "student")]
        [HttpGet]
        [Route("api/student")]
        public IHttpActionResult GetStudent()
        {
            return Ok(lstStudent);  //status code 200
        }

        /// <summary>
        ///     GET : api/student/{enrollment}
        ///     To get details of particular student
        ///     This functionality is only provided to the user whoose role is student
        /// </summary>
        /// <param name="enrollment"> Enrollment (u01f01) of the student object which we want to get</param>
        /// <returns> Details of particular student object with that enrollment id </returns>
        [UserAuthorizationAttribute(Roles = "student")]
        [HttpGet]
        [Route("api/student/{enrollment}")]
        public IHttpActionResult GetStudent(int enrollment)
        {
            Student currentStudent = lstStudent.FirstOrDefault( student  => student.u01f01 == enrollment);

            if(currentStudent == null)
            {
                return NotFound(); // status code 404
            }
            else
            {
                return Ok(currentStudent); //status code 200 
            }

        }

        /// <summary>
        ///     POST : /api/student
        ///     Adds the object of student in database
        ///     This functionality is only provided to the user whoose role is teacher
        /// </summary>
        /// <param name="student"> Object of student which we want to add in database </param>
        /// <returns> List of all students with added object </returns>
        [UserAuthorizationAttribute(Roles = "teacher")]
        [HttpPost]
        [Route("api/student")]
        public IHttpActionResult PostStudent(Student student)
        {
            lstStudent.Add(student);
            //return Ok(lstStudent);  //status code 200
            return Created("Student entry created successfully", student);  // status code 201
        }

        /// <summary>
        ///     PUT : /api/student/{enrollment}
        ///     Updates the object of student in database
        ///     Updates all details within the object
        ///     This functionality is only provided to the user whoose role is teacher
        /// </summary>
        /// <param name="enrollment"> Enrollment (u01f01) of the student object which we want to update </param>
        /// <param name="student"> New object of student which we want to add in the database with that enrollment </param>
        /// <returns> List of all students with updated object </returns>
        [UserAuthorizationAttribute(Roles = "teacher")]
        [HttpPut]
        [Route("api/student/{enrollment}")]
        public IHttpActionResult PutStudent(int enrollment, Student student) 
        {
            int index = lstStudent.FindIndex(stu => stu.u01f01 == enrollment);

            if(index == -1)
            {
                return NotFound();  // Status code 404
            }

            lstStudent[index] = student;

            return Ok(lstStudent); // status code 200
        }

        /// <summary>
        ///     PUT : /api/student/{enrollment}
        ///     Updates the object of student in database
        ///     Updates only name of the student , no need to provide other details
        ///     This functionality is only provided to the user whoose role is teacher
        /// </summary>
        /// <param name="enrollment"> Enrollment (u01f01) of the student object which we want to update </param>
        /// <param name="name"> name of student which we want to modify in the database    </param>
        /// <returns> List of all students with updated object </returns>
        [UserAuthorizationAttribute(Roles = "teacher")]
        [HttpPatch]
        [Route("api/student/{enrollment}")]
        public IHttpActionResult PatchStudent(int enrollment, string name)
        {
            int index = lstStudent.FindIndex(stu => stu.u01f01 == enrollment);

            if (index == -1)
            {
                //return NotFound(); // status code 404
                return BadRequest("Invalid enrollment ID"); // status code 400
            }

            lstStudent[index].u01f02 = name;

            return Ok(lstStudent); // status code 200 
        }

        /// <summary>
        ///     DELETE : /api/student/{enrollment}
        ///     Deletes the object of student in database
        ///     This functionality is only provided to the user whoose role is hod 
        /// </summary>
        /// <param name="enrollment"> Enrollment (u01f01) of the student object which we want to delete </param>
        /// <returns> Updated List of all students after deletion of that object </returns>
        [UserAuthorizationAttribute(Roles = "hod")]
        [HttpDelete]
        [Route("api/student/{enrollment}")]
        public IHttpActionResult DeleteStudent(int enrollment)
        {
            int index = lstStudent.FindIndex(stu => stu.u01f01 == enrollment);

            if (index == -1)
            {
                return BadRequest("Invalid enrollment ID"); // status code 400
            }

            lstStudent.RemoveAt(index);

            return Ok(lstStudent);  // status code 200
        }
    }
}
