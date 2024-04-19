using ExpenseTracker.Models;
using ExpenseTracker.Models.DTO;
using ExpenseTracker.Models.POCO;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Net;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Consist Buisness Logic of all methods related to Expense
    /// </summary>
    public class BLExp01Handler
    {
        #region Private Members
    
        /// <summary>
        /// user id retrieved from current user context
        /// </summary>
        private readonly int _r01f01 = Common.GetUserIdFromClaims();

        /// <summary>
        /// POCO Moodel
        /// </summary>
        private Exp01 _objExp01;

        /// <summary>
        /// object of response to HTTP Action Result 
        /// </summary>
        private readonly Response _objResponse;

        #endregion

        #region Public Members

        /// <summary>
        /// Type of operation
        /// </summary>
        public EnmOperation operation;

        #endregion

        #region Constructor

        /// <summary>
        /// initializes object of response 
        /// </summary>
        public BLExp01Handler()
        {
            _objResponse = new Response();
        }

        #endregion

        #region Public Methods 

        /// <summary>
        /// Pre Delete Validation method 
        /// </summary>
        /// <param name="p01f01"></param>
        /// <returns> object of response </returns>
        public Response PreDeleteValidate(int p01f01)
        {
            if (!IsIdExists(p01f01))
            {
                _objResponse.SetResponse(true, HttpStatusCode.BadRequest, "expense id does not exists", null);
                return _objResponse;
            }

            return _objResponse;
        }

        /// <summary>
        /// Convert DTO model to POCO Model 
        /// </summary>
        /// <param name="objDTOExp01"> dto model of expense </param>
        public void Presave(DTOExp01 objDTOExp01)
        {
            _objExp01 = objDTOExp01.ConvertModel<Exp01>();

            // set userid 
            _objExp01.P01f02 = _r01f01;

            if(operation == EnmOperation.C)
            {
                // set creation time
                _objExp01.P01f07 = DateTime.Now; 
            }
            else if (operation == EnmOperation.U)
            {
                // set updation time 
                _objExp01.P01f08 = DateTime.Now;
            }
        }


        /// <summary>
        /// Validate POCO Model 
        /// </summary>
        /// <returns> object of response </returns>
        public Response Validate()
        {
            if (operation == EnmOperation.U)
            {
                if (!IsIdExists(_objExp01.P01f01))
                {
                    _objResponse.SetResponse(true, HttpStatusCode.BadRequest, "expense id does not exists", null);
                    return _objResponse;
                }
            }

            return _objResponse;
        }

        /// <summary>
        /// Save expense details in database
        /// Can be update or add
        /// </summary>
        /// <returns> object of response </returns>
        public Response Save()
        {
            if (EnmOperation.C == operation)
            {
                // add expense in databse
                using (var db = Common.OrmContext.OpenDbConnection())
                {
                    db.Insert<Exp01>(_objExp01);
                }

                _objResponse.SetResponse("expense added", null);
                return _objResponse;
            }
            else if (EnmOperation.U == operation)
            {
                // update in database
                using (var db = Common.OrmContext.OpenDbConnection())
                {
                    db.Update<Exp01>(_objExp01);
                }

                _objResponse.SetResponse("expnse updated", null);

                return _objResponse;
            }

            return _objResponse;
        }

        /// <summary>
        /// Get all expense details for specific user
        /// </summary>
        /// <returns> List of expense detail for that userId</returns>
        public Response GetAllExpense()
        {
            List<DTOExp01> lstDTOExp01 = new List<DTOExp01>();
            List<Exp01> lstExp01;

            using (var db = Common.OrmContext.OpenDbConnection())
            {
                lstExp01 = db.Select<Exp01>(exp => exp.P01f02.Equals(_r01f01));
            }

            foreach (Exp01 objExp01 in lstExp01)
            {
                lstDTOExp01.Add(objExp01.ConvertModel<DTOExp01>());
            }

            _objResponse.SetResponse("All expenses", lstDTOExp01.ToDataTable<DTOExp01>());

            return _objResponse;
        }

        /// <summary>
        /// Delete expense from database
        /// </summary>
        /// <param name="p01f01"> expense id </param>
        /// <returns></returns>
        public Response DeleteExp01(int p01f01)
        {
            // delete in database

            using (var db = Common.OrmContext.OpenDbConnection())
            {
                // Check if the user is authorized to delete the expense
                db.Delete<Exp01>(x => x.P01f01 == p01f01);
            }

            _objResponse.SetResponse(System.Net.HttpStatusCode.OK, "expense deleted", null);

            return _objResponse;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Id exists in database or not also check access upon that id in context of user id 
        /// </summary>
        /// <param name="p01f01"> expense id </param>
        /// <returns> object of response </returns>
        private bool IsIdExists(int p01f01)
        {
            using (var db = Common.OrmContext.OpenDbConnection())
            {
                return db.Exists<Exp01>(x => x.P01f01 == p01f01 && x.P01f02 == _r01f01);
            }
        }

        #endregion
    }
}