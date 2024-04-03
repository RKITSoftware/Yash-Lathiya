using DI_3_Extension_Methods_For_Registration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DI_3_Extension_Methods_For_Registration.Controllers
{
    /// <summary>
    /// Test Controller which demonstrates Extension method for registration
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLTest : ControllerBase
    {
        #region Private Members

        private readonly IStudentService _studentService;

        #endregion

        #region Public Members
        
        /// <summary>
        /// reference to IStudentService Interface 
        /// </summary>
        /// <param name="studentService"></param>
        public CLTest(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Get all students from interface implementation 
        /// </summary>
        /// <returns> List of all students </returns>
        [HttpGet]
        [Route("TestMethod")]
        public IActionResult TestMethod()
        {
            return Ok(_studentService.GetStudents());
        }

        #endregion

    }
}
