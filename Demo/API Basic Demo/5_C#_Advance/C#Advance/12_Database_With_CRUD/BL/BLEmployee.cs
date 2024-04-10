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

        // To use Credit Service 
        private EmployeeService _objEmployeeService;

        // POCO Moodel
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

        #region Public Members

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
        public bool Validate()
        {
            // validate annual package
            if(_objEmp01.p01f04 < 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Add or update credit in database as per operation 
        /// </summary>
        /// <param name="opeartion"> Create => Create database record
        ///                          Update  => Update database record
        /// </param>
        public void Save(Operation op)
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
            }
            // Update Database Record
            else if (Operation.Update == op)
            {
                // set updation time
                _objEmp01.p01f06 = DateTime.Now;

                _objEmployeeService.UpdateEmployee(_objEmp01);
            }
            // Delete Database Record
            else if(Operation.Delete == op)
            {
                _objEmployeeService.DeleteEmployee(_objEmp01.p01f01);
            }
        }

        /// <summary>
        /// Get Emplyee 
        /// </summary>
        /// <param name="p01f01"></param>
        /// <returns></returns>
        public DTOEmp01 GetEmployee(int p01f01)
        {
            _objEmp01 = _objEmployeeService.GetEmployee(p01f01);

            DTOEmp01 objDTOEmp01 = _objEmp01.ConvertModel<DTOEmp01>();

            return objDTOEmp01;
        }

        #endregion
    }
}