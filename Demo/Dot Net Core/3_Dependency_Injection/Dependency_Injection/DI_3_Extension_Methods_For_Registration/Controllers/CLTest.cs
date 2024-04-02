using DI_3_Extension_Methods_For_Registration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_3_Extension_Methods_For_Registration.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CLTest : ControllerBase
    {
        private readonly IStudentService _studentService;

        public CLTest(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("TestMethod")]
        public IActionResult TestMethod()
        {
            return Ok(_studentService.GetStudents());
        }

    }
}
