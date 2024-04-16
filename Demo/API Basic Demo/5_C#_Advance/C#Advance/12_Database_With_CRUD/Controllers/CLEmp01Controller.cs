﻿using _12_Database_With_CRUD.BL;
using _12_Database_With_CRUD.Filter;
using _12_Database_With_CRUD.Models;
using System.Net.Http;
using System.Web.Http;
using static _12_Database_With_CRUD.BL.Common;

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
        private readonly BLEmp01 _objBLEmp01;

        /// <summary>
        /// Response of HTTP Action method 
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Create Instance of BLEmp01 
        /// </summary>
        public CLEmp01Controller()
        {
            _objBLEmp01 = new BLEmp01();
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
        [Route("api/Emp01/add")]
        public HttpResponseMessage AddEmp01([FromBody] DTOEmp01 objDTOEmp01)
        {
            // set operation enum 
            _objBLEmp01.operation = Operation.Create;

            // presave
            _objBLEmp01.Presave(objDTOEmp01);

            // validate
            _objResponse = _objBLEmp01.Validate();

            if(_objResponse.IsError == false)
            {
                // save
                _objResponse = _objBLEmp01.Save();
            }

            return _objResponse.ToHttpResponseMessage();
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
            _objResponse = _objBLEmp01.GetEmp01(p01f01);

            return _objResponse.ToHttpResponseMessage();
        }

        /// <summary>
        /// To update Emp01 details in the database
        /// </summary>
        /// <param name="objEmp01"> Details which will be saved </param>
        /// <returns> Response </returns>
        [HttpPut]
        [ValidateModel]
        [Route("api/Emp01/Update")]
        public HttpResponseMessage UpdateEmp01([FromBody] DTOEmp01 objDTOEmp01)
        {
            // set operation enum 
            _objBLEmp01.operation = Operation.Update;

            // presave 
            _objBLEmp01.Presave(objDTOEmp01);

            // validate
            _objResponse = _objBLEmp01.Validate();

            if (_objResponse.IsError == false)
            {
                // save 
                _objResponse = _objBLEmp01.Save();
            }

            return _objResponse.ToHttpResponseMessage();

        }

        /// <summary>
        /// To delete Emp01 in the database by Emp01 id
        /// </summary>
        /// <param name="p01f01"> Emp01 id </param>
        /// <returns> Ok </returns>
        [HttpDelete]
        [Route("api/Emp01/Delete")]
        public HttpResponseMessage DeleteEmp01(int p01101)
        {
            // pre validate delete
            if (_objBLEmp01.IsIdExists(p01101))
            {
                // delete
                _objResponse = _objBLEmp01.DeleteEmp01(p01101);
            }
            else
            {
                _objResponse = new Response
                {
                    IsError = true,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "ID does not exists"
                };
            }

            return _objResponse.ToHttpResponseMessage();
        }

        #endregion
    }
}
