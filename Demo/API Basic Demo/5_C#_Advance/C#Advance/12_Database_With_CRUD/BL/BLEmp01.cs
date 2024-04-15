using _12_Database_With_CRUD.Models;
using _12_Database_With_CRUD.Services;
using System;
using System.Data;
using static _12_Database_With_CRUD.BL.Common;

namespace _12_Database_With_CRUD.BL
{
    public class BLEmp01
    {
        #region Public Members

        /// <summary>
        /// Type of operation 
        /// </summary>
        public Operation operation;

        #endregion

        #region Private Members

        /// <summary>
        /// To use Credit Service
        /// </summary>
        private readonly DbEmp01Context _objDbEmp01Context;

        /// <summary>
        /// POCO Moodel
        /// </summary>
        private Emp01 _objEmp01;

        /// <summary>
        /// Response of Action method
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialized necessarymembers to excute BL properly 
        /// </summary>
        public BLEmp01()
        {
            _objDbEmp01Context = new DbEmp01Context();
            _objResponse = new Response();
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

            if(operation == Operation.Create)
            {
                _objEmp01.P01f05 = DateTime.Now;
            }
            else if(operation == Operation.Update)
            {
                _objEmp01.P01f06 = DateTime.Now;
            }
        }

        /// <summary>
        /// Validate POCO Model 
        /// </summary>
        /// <returns> object of response </returns>
        public Response Validate()
        {
            if (operation == Operation.Update)
            {
                if (!IsIdExists(_objEmp01.P01f01))
                {
                    _objResponse.IsError = true;
                    _objResponse.Message = "Id does not exists !!";
                    _objResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;

                    return _objResponse;
                }
            }

            return _objResponse;
        }

       /// <summary>
       /// Add or update employee
       /// </summary>
       /// <returns> object of response </returns>
        public Response Save()
        {
            // Create Database Record
            if (Operation.Create == operation)
            {
                _objDbEmp01Context.AddEmp01(_objEmp01);

                // configuring response message 
                _objResponse.StatusCode = System.Net.HttpStatusCode.Created;
                _objResponse.Message = "Details of Emp01 added in database";

                return _objResponse;
            }
            // Update Database Record
            else if (Operation.Update == operation)
            {
                _objDbEmp01Context.UpdateEmp01(_objEmp01);

                // configuring response message 
                _objResponse.StatusCode = System.Net.HttpStatusCode.Accepted;
                _objResponse.Message = "Details of Emp01 updated in database";

                return _objResponse;
            }

            return _objResponse;
        }

        /// <summary>
        /// Get Emp01 
        /// </summary>
        /// <param name="p01f01"></param>
        /// <returns> Response </returns>
        public Response GetEmp01(int p01f01)
        {
            DataTable dtEmp = _objDbEmp01Context.GetEmp01(p01f01);

            _objResponse.Data = dtEmp;
            _objResponse.Message = "Employee Details";

            return _objResponse;
        }

        /// <summary>
        /// Delete Emp01 from database
        /// </summary>
        /// <param name="p01f01"> Emp01 id </param>
        /// <returns> Response </returns>
        public Response DeleteEmp01(int p01f01)
        {
            _objResponse = _objDbEmp01Context.DeleteEmp01(p01f01);

            return _objResponse;
        }

        /// <summary>
        /// Is id exists in database or not 
        /// </summary>
        /// <param name="p01f01"> Emp01 id </param>
        /// <returns> true => if exists
        ///           false => otherwise
        /// </returns>
        public bool IsIdExists(int p01f01)
        {
            return _objDbEmp01Context.IsIdExists(p01f01);
        }

        #endregion

    }
}