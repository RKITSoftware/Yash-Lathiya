using _12_Database_With_CRUD.BL;
using _12_Database_With_CRUD.Models;
using _12_Database_With_CRUD.Static;
using System.Net.Http;
using System.Web.Http;

namespace _12_Database_With_CRUD.Controllers
{
    /// <summary>
    /// Controller which perform operation in database of Emp01
    /// </summary>
    public class CLEmp01Controller : ApiController
    {
        #region Private Members

        /// <summary>
        /// Emp01 Manager
        /// </summary>
        private BLEmp01 _objBLEmp01;

        /// <summary>
        /// Response of HTTP Action method 
        /// </summary>
        private Response _response;

        #endregion

        #region Public Methods

        /// <summary>
        /// Add Emp01 details in database
        /// </summary>
        /// <param name="objEmp01"> Data which will be added </param>
        /// <returns> Ok </returns>
        [HttpPost]
        [Route("api/Emp01/add")]
        public HttpResponseMessage AddEmp01([FromBody] DTOEmp01 objDTOEmp01)
        {
            _objBLEmp01 = new BLEmp01(Static.Static.Operation.Create);

            // presave
            _objBLEmp01.Presave(objDTOEmp01);

            // validate
            _response = _objBLEmp01.Validate();

            if(_response.IsError == false)
            {
                // save
                _response = _objBLEmp01.Save();
            }

            return _response.ToHttpResponseMessage();
        }

        /// <summary>
        /// Get Emp01 Deatil by Emp01 id
        /// </summary>
        /// <param name="p01f01"> Emp01 id </param>
        /// <returns> Object of Emp01 class </returns>
        [HttpGet]
        [Route("api/Emp01/Get/{p01f01}")]
        public HttpResponseMessage GetEmp01(int p01f01)
        {
            _objBLEmp01 = new BLEmp01(Static.Static.Operation.Retrieve);

            _response = _objBLEmp01.GetEmp01(p01f01);

            return _response.ToHttpResponseMessage();
        }

        /// <summary>
        /// To update Emp01 details in the database
        /// </summary>
        /// <param name="objEmp01"> Details which will be saved </param>
        /// <returns> Response </returns>
        [HttpPut]
        [Route("api/Emp01/Update")]
        public HttpResponseMessage UpdateEmp01([FromBody] DTOEmp01 objDTOEmp01)
        {
            _objBLEmp01 = new BLEmp01(Static.Static.Operation.Update);

            // presave 
            _objBLEmp01.Presave(objDTOEmp01);

            // validate
            _response = _objBLEmp01.Validate();

            if (_response.IsError == false)
            {
                // save 
                _response = _objBLEmp01.Save();
            }

            return _response.ToHttpResponseMessage();

        }

        /// <summary>
        /// To delete Emp01 in the database by Emp01 id
        /// </summary>
        /// <param name="p01f01"> Emp01 id </param>
        /// <returns> Ok </returns>
        [HttpDelete]
        [Route("api/Emp01/Delete")]
        public HttpResponseMessage DeleteEmp01(int p01f01)
        {
            // pre delete validate 
            _response = _objBLEmp01.IsIdExists(p01f01);

            if (_response.IsError == false)
            {
                // delete
                _response = _objBLEmp01.DeleteEmp01(p01f01);
            }

            return _response.ToHttpResponseMessage();
        }

        #endregion
    }
}
