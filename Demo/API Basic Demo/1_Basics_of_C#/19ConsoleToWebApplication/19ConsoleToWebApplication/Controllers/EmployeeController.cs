using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _19ConsoleToWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Public Methods for Routing 

        /// <summary>
        /// Single Employee detail
        /// </summary>
        /// <returns>Single Employee detail</returns>
        [Route("")]
        public IActionResult GetEmployees()
        {
            EmployeeModel model = new EmployeeModel(1, "Employee1");
            return Ok(model);
        }

        /// <summary>
        /// List of employee
        /// </summary>
        /// <param name="id">employeeId</param>
        /// <returns>List of employee</returns>
        [Route("{id}")]
        public IActionResult GetEmployee(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            return Ok(new List<EmployeeModel>() {
                new EmployeeModel(1, "Employee 1") ,
                new EmployeeModel(2, "Employee 2") }
            );
        }

        #endregion
    }

    /// <summary>
    /// Employee class with id and name details
    /// </summary>
    public class EmployeeModel
    {
        public int id;
        public string employeeName;

        public EmployeeModel()
        {
        }

        public EmployeeModel(int id, string employeeName)
        {
            this.id = id;
            this.employeeName = employeeName;
        }
    }
}
