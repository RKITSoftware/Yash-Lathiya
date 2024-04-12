using _12_Database_With_CRUD.Models;
using _12_Database_With_CRUD.Services;
using _12_Database_With_CRUD.Static;
using System;
using static _12_Database_With_CRUD.Static.Static;

namespace _12_Database_With_CRUD.BL
{
    public class BLEmp01
    {
        #region Private Members

        /// <summary>
        /// To use Credit Service
        /// </summary>
        private DbEmp01Context _objEmp01Service;

        /// <summary>
        /// POCO Moodel
        /// </summary>
        private Emp01 _objEmp01;

        /// <summary>
        /// Response of Action method
        /// </summary>
        private Response _response;

        /// <summary>
        /// Type of operation 
        /// </summary>
        private Operation _operation;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialized necessarymembers to excute BL properly 
        /// </summary>
        public BLEmp01(Operation operation)
        {
            _objEmp01Service = new DbEmp01Context();
            _response = new Response();
            _operation = operation;
        }

        #endregion

        #region Public Methods 
        
        /// <summary>
        /// Convert DTO model to POCO Model 
        /// </summary>
        /// <param name="objDTOCre01"> DTO of Emp01 </param>
        public void Presave(DTOEmp01 objDTOEmp01)
        {
            _objEmp01 = objDTOEmp01.ConvertModel<Emp01>();
        }

        /// <summary>
        /// Validate POCO Model 
        /// </summary>
        /// <returns>true if validated else false </returns>
        public Response Validate()
        {
            // validate annual package
            if(_objEmp01.P01f04 <= 0)
            {
                _response.IsError = true;
                _response.Message = "Annual package is not valid";
                _response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                return _response;
            }

            return _response;
        }

        /// <summary>
        /// Add or update credit in database as per operation 
        /// </summary>
        /// <param name="opeartion"> Create => Create database record
        ///                          Update  => Update database record
        /// </param>
        public Response Save()
        {
            // Create Database Record
            if (Operation.Create == _operation)
            {
                // set creation time
                _objEmp01.P01f05 = DateTime.Now;
                // set updation time
                _objEmp01.P01f06 = DateTime.Now;

                _objEmp01Service = new DbEmp01Context();
                _objEmp01Service.AddEmp01(_objEmp01);

                // configuring response message 
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                _response.Message = "Details of Emp01 added in database";

                return _response;
            }
            // Update Database Record
            else if (Operation.Update == _operation)
            {
                // set updation time
                _objEmp01.P01f06 = DateTime.Now;

                _objEmp01Service.UpdateEmp01(_objEmp01);


                // configuring response message 
                _response.StatusCode = System.Net.HttpStatusCode.Accepted;
                _response.Message = "Details of Emp01 updated in database";

                return _response;
            }

            return _response;
        }

        /// <summary>
        /// Get Emp01 
        /// </summary>
        /// <param name="p01f01"></param>
        /// <returns> Response </returns>
        public Response GetEmp01(int p01f01)
        {
            _response = _objEmp01Service.GetEmp01(p01f01);

            return _response;
        }

        /// <summary>
        /// Delete Emp01 from database
        /// </summary>
        /// <param name="p01f01"> Emp01 id </param>
        /// <returns> Response </returns>
        public Response DeleteEmp01(int p01f01)
        {
            _response = _objEmp01Service.DeleteEmp01(p01f01);

            return _response;
        }

        /// <summary>
        /// Is id exists in database or not 
        /// </summary>
        /// <param name="p01f01"> Emp01 id </param>
        /// <returns> true => if exists
        ///           false => otherwise
        /// </returns>
        public Response IsIdExists(int p01f01)
        {
            _response = _objEmp01Service.IsIdExists(p01f01);

            return _response;
        }

        #endregion

    }
}