using _12_Database_With_CRUD.BL;
using _12_Database_With_CRUD.Models;
using _12_Database_With_CRUD.Static;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _12_Database_With_CRUD.Controllers
{
    /// <summary>
    /// Controller which perform operation in database of Employee
    /// </summary>
    public class CLEmployeeController : ApiController
    {
        #region Private Members

        /// <summary>
        /// Employee Manager
        /// </summary>
        private readonly BLEmployee _objEmployeeManager;

        /// <summary>
        /// Response of HTTP Action method 
        /// </summary>
        private Response _response;

        #endregion

        #region Constructor

        /// <summary>
        /// Take reference of Employee Manager
        /// And initializes response 
        /// </summary>
        public CLEmployeeController()
        {
            _objEmployeeManager = new BLEmployee();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add employee details in database
        /// </summary>
        /// <param name="objEmp01"> Data which will be added </param>
        /// <returns> Ok </returns>
        [HttpPost]
        [Route("api/Employee/add")]
        public HttpResponseMessage AddEmployee([FromBody] DTOEmp01 objDTOEmp01)
        {
            _objEmployeeManager.Presave(objDTOEmp01);

            _response = _objEmployeeManager.Validate();

            if(_response.IsError == false)
            {
                _response = _objEmployeeManager.Save(Static.Static.Operation.Create);
            }

            return _response.ToHttpResponseMessage();
        }

        /// <summary>
        /// Get Employee Deatil by employee id
        /// </summary>
        /// <param name="p01f01"> EMployee id </param>
        /// <returns> Object of Emp01 class </returns>
        [HttpGet]
        [Route("api/Employee/Get/{p01f01}")]
        public HttpResponseMessage GetEmployee(int p01f01)
        {
            _response = _objEmployeeManager.GetEmployee(p01f01);

            return _response.ToHttpResponseMessage();
        }

        /// <summary>
        /// To update employee details in the database
        /// </summary>
        /// <param name="objEmp01"> Details which will be saved </param>
        /// <returns> Response </returns>
        [HttpPut]
        [Route("api/Employee/Update")]
        public HttpResponseMessage UpdateEmployee([FromBody] DTOEmp01 objDTOEmp01)
        {
            _objEmployeeManager.Presave(objDTOEmp01);

            _response = _objEmployeeManager.Validate();

            if (_response.IsError == false)
            {
                _response = _objEmployeeManager.Save(Static.Static.Operation.Update);
            }

            return _response.ToHttpResponseMessage();

        }

        /// <summary>
        /// To delete employee in the database by employee id
        /// </summary>
        /// <param name="p01f01"> employee id </param>
        /// <returns> Ok </returns>
        [HttpDelete]
        [Route("api/Employee/Delete")]
        public HttpResponseMessage DeleteEmployee([FromBody] DTOEmp01 objDTOEmp01)
        {
            _objEmployeeManager.Presave(objDTOEmp01);

            if (_response.IsError == false)
            {
                _response = _objEmployeeManager.Save(Static.Static.Operation.Delete);
            }

            return _response.ToHttpResponseMessage();

        }

        #endregion
    }
}
