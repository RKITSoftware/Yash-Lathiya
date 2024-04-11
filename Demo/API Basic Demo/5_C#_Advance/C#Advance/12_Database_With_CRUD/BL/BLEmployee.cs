using _12_Database_With_CRUD.Models;
using _12_Database_With_CRUD.Services;
using _12_Database_With_CRUD.Static;
using System;
using static _12_Database_With_CRUD.Static.Static;

namespace _12_Database_With_CRUD.BL
{
    public class BLEmployee
    {
        #region Private Members

        /// <summary>
        /// To use Credit Service
        /// </summary>
        private DbEmp01Context _objEmployeeService;

        /// <summary>
        /// POCO Moodel
        /// </summary>
        private Emp01 _objEmp01;

        /// <summary>
        /// Response of Action method
        /// </summary>
        private Response _response;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialized Employee Service 
        /// </summary>
        public BLEmployee()
        {
            _objEmployeeService = new DbEmp01Context();
            _response = new Response();
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
        public Response Save(Operation op)
        {
            // Create Database Record
            if (Operation.Create == op)
            {
                // set creation time
                _objEmp01.P01f05 = DateTime.Now;
                // set updation time
                _objEmp01.P01f06 = DateTime.Now;

                _objEmployeeService = new DbEmp01Context();
                _objEmployeeService.AddEmployee(_objEmp01);

                // configuring response message 
                _response.StatusCode = System.Net.HttpStatusCode.Created;
                _response.Message = "Details of employee added in database";

                return _response;
            }
            // Update Database Record
            else if (Operation.Update == op)
            {
                // set updation time
                _objEmp01.P01f06 = DateTime.Now;

                _objEmployeeService.UpdateEmployee(_objEmp01);


                // configuring response message 
                _response.StatusCode = System.Net.HttpStatusCode.Accepted;
                _response.Message = "Details of employee updated in database";

                return _response;
            }
            // Delete Database Record
            else if(Operation.Delete == op)
            {
                _objEmployeeService.DeleteEmployee(_objEmp01.P01f01);

                // configuring response message 
                _response.StatusCode = System.Net.HttpStatusCode.Accepted;
                _response.Message = "Details of employee deleted in database";

                return _response;
            }

            return _response;
        }

        /// <summary>
        /// Get Employee 
        /// </summary>
        /// <param name="p01f01"></param>
        /// <returns></returns>
        public Response GetEmployee(int p01f01)
        {
            _response = _objEmployeeService.GetEmployee(p01f01);

            return _response;
        }

        #endregion
    }
}