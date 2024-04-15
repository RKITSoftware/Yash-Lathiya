using _12_Database_With_CRUD.Models;
using _12_Database_With_CRUD.Services;
using ServiceStack.OrmLite;
using System;
using static _12_Database_With_CRUD.Static.Static;

namespace _12_Database_With_CRUD.BL
{
    public class BLEmp01ORM
    {
        #region Private Members

        /// <summary>
        /// POCO Moodel
        /// </summary>
        private Emp01 _objEmp01;

        /// <summary>
        /// Response of Action Method
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Public Members

        /// <summary>
        /// Which type of operation is performing on database 
        /// </summary>
        public Operation operation;

        #endregion

        #region Public Methods

        /// <summary>
        /// Convert DTO model to POCO Model 
        /// </summary>
        /// <param name="objDTOEmp01"> DTO of Emp01 </param>
        public void Presave(DTOEmp01 objDTOEmp01)
        {
            _objEmp01 = objDTOEmp01.ConvertModel<Emp01>();
        }

        /// <summary>
        /// Validate POCO Model 
        /// </summary>
        /// <returns> object of response </returns>
        public Response Validate()
        {
            _objResponse = new Response();

            // validate annual package
            if (_objEmp01.P01f04 <= 0)
            {
                _objResponse.IsError = true;
                _objResponse.Message = "Annual package is not valid";
                _objResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;

                return _objResponse;
            }

            return _objResponse;
        }

        /// <summary>
        /// Add or update employee
        /// </summary>
        /// <returns> object of response </returns>
        public Response Save()
        {
            _objResponse = new Response();

            // Create Database Record
            if (Operation.Create == operation)
            {
                // set creation time
                _objEmp01.P01f05 = DateTime.Now;
                // set updation time
                _objEmp01.P01f06 = DateTime.Now;


                using (var db = Static.Static.OrmContext.OpenDbConnection())
                {
                    db.Insert<Emp01>(_objEmp01);

                    _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    _objResponse.Data = null;
                    _objResponse.Message = "Employee Added";

                    return _objResponse;
                }
            }
            // Update Database Record
            else if (Operation.Update == operation)
            {
                // set updation time
                _objEmp01.P01f06 = DateTime.Now;

                // update in database
                using (var db = Static.Static.OrmContext.OpenDbConnection())
                {
                    db.Update<Emp01>(_objEmp01);

                    _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    _objResponse.Data = null;
                    _objResponse.Message = "Employee Updated";

                    return _objResponse;
                }
            }

            return _objResponse;
        }

        /// <summary>
        /// Get employee details from the database
        /// </summary>
        /// <param name="p01f01"> employee id </param>
        /// <returns> object of response </returns>
        public Response GetEmp01(int p01f01)
        {
            _objResponse = new Response();

            DbEmp01Context objDbEmp01Context = new DbEmp01Context();
            
            return objDbEmp01Context.GetEmp01(p01f01);
        }

        /// <summary>
        /// Delete employee from database
        /// </summary>
        /// <param name="p01f01"> employee id </param>
        /// <returns></returns>
        public Response DeleteEmp01(int p01f01)
        {
            _objResponse = new Response();

            // delete in database
            using (var db = Static.Static.OrmContext.OpenDbConnection())
            {
                db.DeleteById<Emp01>(p01f01);
            }

            _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
            _objResponse.Data = null;
            _objResponse.Message = "Employee Deleted";

            return _objResponse;
        }

        /// <summary>
        /// Id exists in database or not
        /// </summary>
        /// <param name="p01f01"> employee id </param>
        /// <returns> object of response </returns>
        public Response IsIdExists(int p01f01)
        {
            bool isExists;
            _objResponse = new Response();

            using (var db = Static.Static.OrmContext.OpenDbConnection())
            {
                    isExists = db.Exists<Emp01>(x => x.P01f01 == p01f01);
            }

            _objResponse.IsError = !isExists;
            _objResponse.Message = !isExists ? "Id exists in database" : "id does not exists in database ";
            _objResponse.StatusCode = !isExists ? System.Net.HttpStatusCode.BadRequest : System.Net.HttpStatusCode.OK;
            _objResponse.Data = null;

            return _objResponse;
        }

        #endregion
    }
}