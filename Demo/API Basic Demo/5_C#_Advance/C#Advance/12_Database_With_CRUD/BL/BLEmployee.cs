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
        private EmployeeService _objEmployeeService;

        /// <summary>
        /// POCO Moodel
        /// </summary>
        private Emp01 _objEmp01;

        #endregion

        #region Constructor

        /// <summary>
        /// Initialized Employee Service 
        /// </summary>
        public BLEmployee()
        {
            _objEmployeeService = new EmployeeService();
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
        public Response Validate(Response response)
        {
            // validate annual package
            if(_objEmp01.p01f04 < 0)
            {
                response.isError = true;
                response.message = "Annual package is not valid";
                response.statusCode = System.Net.HttpStatusCode.BadRequest;

                return response;
            }

            return response;
        }

        /// <summary>
        /// Add or update credit in database as per operation 
        /// </summary>
        /// <param name="opeartion"> Create => Create database record
        ///                          Update  => Update database record
        /// </param>
        public Response Save(Operation op, Response response)
        {
            // Create Database Record
            if (Operation.Create == op)
            {
                // set creation time
                _objEmp01.p01f05 = DateTime.Now;
                // set updation time
                _objEmp01.p01f06 = DateTime.Now;

                _objEmployeeService = new EmployeeService();
                _objEmployeeService.AddEmployee(_objEmp01);

                // configuring response message 
                response.statusCode = System.Net.HttpStatusCode.Created;
                response.message = "Details of employee added in database";

                return response;
            }
            // Update Database Record
            else if (Operation.Update == op)
            {
                // set updation time
                _objEmp01.p01f06 = DateTime.Now;

                _objEmployeeService.UpdateEmployee(_objEmp01);


                // configuring response message 
                response.statusCode = System.Net.HttpStatusCode.Accepted;
                response.message = "Details of employee updated in database";

                return response;
            }
            // Delete Database Record
            else if(Operation.Delete == op)
            {
                _objEmployeeService.DeleteEmployee(_objEmp01.p01f01);


                // configuring response message 
                response.statusCode = System.Net.HttpStatusCode.Accepted;
                response.message = "Details of employee deleted in database";

                return response;
            }

            return response;
        }

        /// <summary>
        /// Get Emplyee 
        /// </summary>
        /// <param name="p01f01"></param>
        /// <returns></returns>
        public Response GetEmployee(int p01f01, Response response)
        {
            _objEmp01 = _objEmployeeService.GetEmployee(p01f01);

            DTOEmp01 objDTOEmp01 = _objEmp01.ConvertModel<DTOEmp01>();

            // configuring response message 

            response.statusCode = System.Net.HttpStatusCode.OK; 
            response.message = "Fetched Employee Details";
            response.data = objDTOEmp01;
            return response;
        }

        #endregion
    }
}