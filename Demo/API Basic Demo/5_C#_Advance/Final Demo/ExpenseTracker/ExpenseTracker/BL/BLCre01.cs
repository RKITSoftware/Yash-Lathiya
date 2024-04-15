using ExpenseTracker.Models;
using ExpenseTracker.Models.DTO;
using ExpenseTracker.Models.POCO;
using ExpenseTracker.Static;
using Microsoft.IdentityModel.Tokens;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// CreditManager class performs CRUD operation with Cre01 class by using ORM ( CreditService )
    /// </summary>
    public class BLCre01
    {
        #region Private Members

        /// <summary>
        /// user id retrieved from current user context
        /// </summary>
        private readonly int _r01f01 = Static.Static.GetUserIdFromClaims();

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
        public Operation operation;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes necessary memebers for BL of Cre01
        /// </summary>
        public BLCre01()
        {
            _objResponse = new Response();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Convert DTO model to POCO Model 
        /// </summary>
        /// <param name="objDTOCre01"> DTO of Cre01 </param>
        public void Presave(DTOCre01 objDTOCre01)
        {
            _objCre01 = objDTOCre01.ConvertModel<Cre01>();

            // set userid 
            _objCre01.E01f02 = _r01f01;
        }

        /// <summary>
        /// Validate POCO Model 
        /// </summary>
        /// <returns> object of response </returns>
        public Response Validate()
        {
            // credit amount should be graeter then zero
            if (_objCre01.E01f03 <= 0)
            {
                _objResponse.SetResponse(System.Net.HttpStatusCode.BadRequest, "Invalid Credit Amount", null);
                return _objResponse;
            }

            // category of credit can't be null
            if (_objCre01.E01f04.IsNullOrEmpty())
            {
                _objResponse.SetResponse(System.Net.HttpStatusCode.BadRequest, "Credit category is null or empty", null);
                return _objResponse;
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
            // Create Database Record
            if (Operation.Create == operation)
            {
                // set creation time
                _objCre01.E01f05 = DateTime.Now;
                // set updation time
                _objCre01.E01f06 = DateTime.Now;

                try
                {
                    // add credit in databse
                    using (var db = Static.Static.OrmContext.OpenDbConnection())
                    {
                        db.Insert(_objCre01);
                    }

                    _objResponse.SetResponse("Credit added", null);
                }
                catch(Exception ex)
                {
                    _objResponse.SetResponse(true, System.Net.HttpStatusCode.InternalServerError, ex.Message, null);
                }

                return _objResponse;               
            }
            // Update Database Record
            else if (Operation.Update == operation)
            {
                // set updation time
                _objCre01.E01f06 = DateTime.Now;

                // update in database
                try
                {
                    Dictionary<String, object> dictionary = new Dictionary<string, object>();

                    // Loop through properties of objExp01
                    foreach (var prop in typeof(Cre01).GetProperties())
                    {
                        // don't update and creation time
                        if (prop.Name == "e01f05")
                        {
                            continue;
                        }

                        var value = prop.GetValue(_objCre01);
                        if (value != null)
                        {
                            dictionary.Add(prop.Name, value);
                        }
                    }

                    using (var db = Static.Static.OrmContext.OpenDbConnection())
                    {
                        db.UpdateOnly<Cre01>(
                            dictionary,                         // Specify the field to update
                            x => x.E01f01 == _objCre01.E01f01); // Filter condition to set expense id 
                    }

                    _objResponse.SetResponse("credit updated", null);

                }
                catch(Exception ex)
                {
                    _objResponse.SetResponse(true, System.Net.HttpStatusCode.InternalServerError, ex.Message, null);
                }

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
            try
            {
                List<DTOCre01> lstDTOCre01 = new List<DTOCre01>();
                List<Cre01> lstCre01;

                using (var db = Static.Static.OrmContext.OpenDbConnection())
                {
                    lstCre01 = db.Select<Cre01>(credit => credit.E01f02.Equals(_r01f01));
                }

                foreach(Cre01 objCre01 in lstCre01)
                {
                    lstDTOCre01.Add(objCre01.ConvertModel<DTOCre01>());
                }

                _objResponse.SetResponse("All Credits", lstDTOCre01.ToDataTable<DTOCre01>());
            }
            catch(Exception ex)
            {
                _objResponse.SetResponse(true, System.Net.HttpStatusCode.InternalServerError, ex.Message, null);
            }
            
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
            try
            {
                using (var db = Static.Static.OrmContext.OpenDbConnection())
                {
                    // Check if the user is authorized to delete the expense
                    int _r01f01 = Static.Static.GetUserIdFromClaims();
                    db.Delete<Cre01>(x => x.E01f01 == e01f01 && x.E01f02 == _r01f01);
                }

                _objResponse.SetResponse(System.Net.HttpStatusCode.OK, "Credit deleted", null);
            }
            catch (Exception ex)
            {
                _objResponse.SetResponse(true, System.Net.HttpStatusCode.InternalServerError, ex.Message, null);
            }

            return _objResponse;
        }

        /// <summary>
        /// Id exists in database or not
        /// </summary>
        /// <param name="e01f01"> credit id </param>
        /// <returns> object of response </returns>
        public Response IsIdExists(int e01f01)
        {
            try
            {
                bool isExists;

                using (var db = Static.Static.OrmContext.OpenDbConnection())
                {
                    isExists = db.Exists<Cre01>(x => x.E01f01 == e01f01);
                }

                _objResponse.SetResponse(isExists, 
                                         System.Net.HttpStatusCode.OK, 
                                         isExists ? "user id exists" : "user id does not exists", 
                                         null);
            }
            catch (Exception ex)
            {
                _objResponse.SetResponse(true, System.Net.HttpStatusCode.InternalServerError, ex.Message, null);
            }

            return _objResponse;
        }

        #endregion
    }
}