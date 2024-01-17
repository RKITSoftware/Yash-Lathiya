//using _2_1_Generics_Stack;
//using _2_1_Generics_Stack.Controllers;
//using _2_1_Generics_Stack.Models;
//using System;
//using System.Collections.Generic;
//using System.Web.Http;

//public class CLApiWithStackController : ApiController
//{
    

//        private IGenericService<Stu01> _studentService;
//        private CLGenStackController<Stu01> _genericStudentController;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="StudentController"/> class.
//        /// </summary>
//        /// <param name="studentService">The generic service for students.</param>
//        public CLApiWithStackController(IGenericService<Stu01> studentService)
//        {
//            _studentService = studentService;

//            // Ensure that _studentService is not null before using it
//            if (_studentService != null)
//            {
//                _genericStudentController = new CLGenStackController<Stu01>(_studentService);
//            }
//        }

//        /// <summary>
//        /// Gets all students.
//        /// </summary>

//        [HttpGet]
//        [Route("api/student")]
//        public IHttpActionResult GetStudents()
//        {
//            // Check if _genericStudentController is initialized
//            if (_genericStudentController == null)
//            {
//                // Log or handle the case where _genericStudentController is null
//                return InternalServerError(new Exception("Generic controller not properly initialized."));
//            }

//            // Call the Get method of GenericController<Student>
//            List<Stu01> students = _genericStudentController.Get();
//            return Ok(students);
//        }
//        /// <summary>
//        /// Gets a student by their unique identifier.
//        /// </summary>
//        /// <param name="id">The unique identifier of the student.</param>
//        [HttpGet]
//        [Route("api/student/{id}")]
//        public IHttpActionResult GetStudent(int id)
//        {
//            // Check if _genericStudentController is initialized
//            if (_genericStudentController == null)
//            {
//                // Log or handle the case where _genericStudentController is null
//                return InternalServerError(new Exception("Generic controller not properly initialized."));
//            }

//            // Call the Get method of GenericController<Student>
//            Stu01 student = _genericStudentController.Get(id);
//            if (student == null)
//                return NotFound();

//            return Ok(student);
//        }

//        /// <summary>
//        /// Adds a new student.
//        /// </summary>
//        /// <param name="student">The student to be added.</param>
//        [HttpPost]
//        [Route("api/student/AddStudent")]
//        public IHttpActionResult AddStudent([FromBody] Stu01 student)
//        {
//            // Check if _genericStudentController is initialized
//            if (_genericStudentController == null)
//            {
//                // Log or handle the case where _genericStudentController is null
//                return InternalServerError(new Exception("Generic controller not properly initialized."));
//            }

//            // Call the Post method of GenericController<Student>
//            List<Stu01> updatedStudents = _genericStudentController.Post(student);
//            return Ok(updatedStudents);
//        }


//        /// <summary>
//        /// Deletes a student by their unique identifier.
//        /// </summary>
//        /// <param name="id">The unique identifier of the student to be deleted.</param>
//        [HttpDelete]
//        [Route("api/student/DeleteStudent")]
//        public IHttpActionResult DeleteStudent(int id)
//        {
//            // Check if _genericStudentController is initialized
//            if (_genericStudentController == null)
//            {
//                // Log or handle the case where _genericStudentController is null
//                return InternalServerError(new Exception("Generic controller not properly initialized."));
//            }

//            // Call the Delete method of GenericController<Student>
//            List<Stu01> updatedStudents = _genericStudentController.Delete(id);
//            return Ok(updatedStudents);
//        }
//    }

