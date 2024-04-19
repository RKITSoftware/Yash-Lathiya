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
    /// CreditManager class performs CRUD operation with Cre01 class by using ORM ( CreditService )
    /// </summary>
    public class BLCre01Handler
    {
        #region Private Members

        /// <summary>
        /// user id retrieved from current user context
        /// </summary>
        private readonly int _r01f01 = Common.GetUserIdFromClaims();

        /// <summary>
        /// POCO Moodel
        /// </summary>
        private Cre01 _objCre01;

        /// <summary>
        /// Response of Action Method
        /// </summary>
        private readonly Response _objResponse;

        #endregion

        #region Public Members

        /// <summary>
        /// Which type of operation is performing on database 
        /// </summary>
        public EnmOperation operation;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes necessary memebers for BL of Cre01
        /// </summary>
        public BLCre01Handler()
        {
            _objResponse = new Response();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Pre Delete Validation method 
        /// </summary>
        /// <param name="e01f01"></param>
        /// <returns> object of response </returns>
        public Response PreDeleteValidate(int e01f01)
        {
            if (!IsIdExists(e01f01))
            {
                _objResponse.SetResponse(true, HttpStatusCode.BadRequest, "credit id does not exists", null);
                return _objResponse;
            }

            return _objResponse;
        }

        /// <summary>
        /// Convert DTO model to POCO Model 
        /// </summary>
        /// <param name="objDTOCre01"> DTO of Cre01 </param>
        public void Presave(DTOCre01 objDTOCre01)
        {
            _objCre01 = objDTOCre01.ConvertModel<Cre01>();

            // set userid 
            _objCre01.E01f02 = _r01f01;

            if(operation == EnmOperation.C)
            {
                // set creation time
                _objCre01.E01f05 = DateTime.Now;
            }
            else if (operation == EnmOperation.U)
            {
                // set updation time
                _objCre01.E01f06 = DateTime.Now;
            }
        }

        /// <summary>
        /// Validate POCO Model 
        /// </summary>
        /// <returns> object of response </returns>
        public Response Validate()
        {
            if(operation == EnmOperation.U)
            {
                if (!IsIdExists(_objCre01.E01f01))
                {
                    _objResponse.SetResponse(true, HttpStatusCode.BadRequest, "credit id does not exists", null);
                    return _objResponse;
                }
            }

            return _objResponse;
        }       

        /// <summary>
        /// Save credit details in database
        /// Can be update or add
        /// </summary>
        /// <returns> object of response </returns>
        public Response Save()
        {
            if (EnmOperation.C == operation)
            {
                // add credit in databse
                using (var db = Common.OrmContext.OpenDbConnection())
                {
                    db.Insert<Cre01>(_objCre01);
                }

                _objResponse.SetResponse("Credit added", null);
                return _objResponse;               
            }
            else if(EnmOperation.U == operation)
            {
                // update in database
                using (var db = Common.OrmContext.OpenDbConnection())
                {
                    db.Update<Cre01>(_objCre01);
                }

                _objResponse.SetResponse("credit updated", null);

                return _objResponse;
            }

            return _objResponse;
        }

        /// <summary>
        /// Get all credit details for specific user
        /// </summary>
        /// <returns> List of Credit detail for that userId</returns>
        public Response GetAllCredit()
        {
            List<DTOCre01> lstDTOCre01 = new List<DTOCre01>();
            List<Cre01> lstCre01;

            using (var db = Common.OrmContext.OpenDbConnection())
            {
                lstCre01 = db.Select<Cre01>(credit => credit.E01f02.Equals(_r01f01));
            }

            foreach (Cre01 objCre01 in lstCre01)
            {
                lstDTOCre01.Add(objCre01.ConvertModel<DTOCre01>());
            }

            _objResponse.SetResponse("All Credits", lstDTOCre01.ToDataTable<DTOCre01>());

            return _objResponse;
        }

        /// <summary>
        /// Delete Credit from database
        /// </summary>
        /// <param name="e01f01"> credit id </param>
        /// <returns></returns>
        public Response DeleteCre01(int e01f01)
        {
            // delete in database
            
            using (var db = Common.OrmContext.OpenDbConnection())
            {
                // Check if the user is authorized to delete the credit
                db.Delete<Cre01>(x => x.E01f01 == e01f01);
            }

            _objResponse.SetResponse(System.Net.HttpStatusCode.OK, "Credit deleted", null);
                
            return _objResponse;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Id exists in database or not also check access upon that id in context of user id 
        /// </summary>
        /// <param name="e01f01"> credit id </param>
        /// <returns> object of response </returns>
        private bool IsIdExists(int e01f01)
        {
            using (var db = Common.OrmContext.OpenDbConnection())
            {
                return db.Exists<Cre01>(x => x.E01f01 == e01f01 && x.E01f02 == _r01f01);
            }
        }

        #endregion
    }
}