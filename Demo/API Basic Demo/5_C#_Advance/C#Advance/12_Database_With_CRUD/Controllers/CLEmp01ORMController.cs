using _12_Database_With_CRUD.BL;
using _12_Database_With_CRUD.Filter;
using _12_Database_With_CRUD.Models;
using System.Web.Http;
using static _12_Database_With_CRUD.BL.Common;

namespace _12_Database_With_CRUD.Controllers
{
    public class CLEmp01ORMController : ApiController
    {
        #region Private Members

        /// <summary>
        /// Emp01 Manager
        /// </summary>
        private readonly BLEmp01ORM _objBLEmp01ORM;

        /// <summary>
        /// Response of HTTP Action method 
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Create Instance of BLEmp01ORM 
        /// </summary>
        public CLEmp01ORMController()
        {
            _objBLEmp01ORM = new BLEmp01ORM();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add Emp01 details in database
        /// </summary>
        /// <param name="objEmp01"> Data which will be added </param>
        /// <returns> Ok </returns>
        [HttpPost]
        [ValidateModel]
        [Route("api/Emp01ORM/add")]
        public IHttpActionResult AddEmp01([FromBody] DTOEmp01 objDTOEmp01)
        {
            // change Static namespace
            _objBLEmp01ORM.operation = Operation.Create;

            // presave
            _objBLEmp01ORM.Presave(objDTOEmp01);

            // validate
            _objResponse = _objBLEmp01ORM.Validate();

            if (!_objResponse.IsError)
            {
                // save
                _objResponse = _objBLEmp01ORM.Save();
            }

            return Ok(_objResponse);
        }

        /// <summary>
        /// Get Emp01 Deatil by Emp01 id
        /// </summary>
        /// <param name="p01f01"> Emp01 id </param>
        /// <returns> Object of Emp01 class </returns>
        [HttpGet]
        [Route("api/Emp01ORM/Get/{p01f01}")]
        public IHttpActionResult GetEmp01(int p01f01)
        {
            _objResponse = _objBLEmp01ORM.GetEmp01(p01f01);

            return Ok(_objResponse);
        }

        /// <summary>
        /// To update Emp01 details in the database
        /// </summary>
        /// <param name="objEmp01"> Details which will be saved </param>
        /// <returns> Response </returns>
        [HttpPut]
        [ValidateModel]
        [Route("api/Emp01ORM/Update")]
        public IHttpActionResult UpdateEmp01([FromBody] DTOEmp01 objDTOEmp01)
        {
            // set operation enum 
            _objBLEmp01ORM.operation = Operation.Update;

            // presave 
            _objBLEmp01ORM.Presave(objDTOEmp01);

            // validate
            _objResponse = _objBLEmp01ORM.Validate();

            if (!_objResponse.IsError)
            {
                // save 
                _objResponse = _objBLEmp01ORM.Save();
            }

            return Ok(_objResponse);

        }

        /// <summary>
        /// To delete Emp01 in the database by Emp01 id
        /// </summary>
        /// <param name="p01f01"> Emp01 id </param>
        /// <returns> Ok </returns>
        [HttpDelete]
        [Route("api/Emp01ORM/Delete")]
        public IHttpActionResult DeleteEmp01(int p01101)
        {
            // pre delete validate 
            _objResponse = _objBLEmp01ORM.ValidateDelete(p01101);

            if (_objResponse.IsError)
            {
                // delete
                _objResponse = _objBLEmp01ORM.DeleteEmp01(p01101);
            }

            return Ok(_objResponse);
        }

        #endregion
    }
}
