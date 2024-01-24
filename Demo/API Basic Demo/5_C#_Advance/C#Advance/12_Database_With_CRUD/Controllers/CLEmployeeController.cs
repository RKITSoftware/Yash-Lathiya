using _12_Database_With_CRUD.BL;
using _12_Database_With_CRUD.Models;
using _12_Database_With_CRUD.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _12_Database_With_CRUD.Controllers
{
    /// <summary>
    /// Controller which perform operation in database of Employee
    /// </summary>
    public class CLEmployeeController : ApiController
    {
        #region Public Methods

        /// <summary>
        /// Add employee details in database
        /// </summary>
        /// <param name="objEmp01"> Data which will be added </param>
        /// <returns> Ok </returns>
        [HttpPost]
        [Route("api/Employee/add")]
        public IHttpActionResult AddEmployee([FromBody] Emp01 objEmp01)
        {
            EmployeeManager.AddEmployee(objEmp01);
            return Ok("Added");
        }

        /// <summary>
        /// Get Employee Deatil by employee id
        /// </summary>
        /// <param name="p01f01"> EMployee id </param>
        /// <returns> Object of Emp01 class </returns>
        [HttpGet]
        [Route("api/Employee/Get/{p01f01}")]
        public IHttpActionResult GetEmployee(int p01f01)
        {
            return Ok(EmployeeManager.GetEmployee(p01f01));
        }

        /// <summary>
        /// To update employee details in the database
        /// </summary>
        /// <param name="objEmp01"> Details which will be saved </param>
        /// <returns> Ok </returns>
        [HttpPut]
        [Route("api/Employee/Update")]
        public IHttpActionResult UpdateEmployee([FromBody] Emp01 objEmp01)
        {
            EmployeeManager.UpdateEmployee(objEmp01);
            return Ok("Updated");
        }

        /// <summary>
        /// To delete employee in the database by employee id
        /// </summary>
        /// <param name="p01f01"> employee id </param>
        /// <returns> Ok </returns>
        [HttpDelete]
        [Route("api/Employee/Delete/{p01f01}")]
        public IHttpActionResult DeleteEmployee(int p01f01)
        {
            EmployeeManager.DeleteEmployee(p01f01);
            return Ok("Deleted");
        }

        #endregion
    }
}
