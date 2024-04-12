using ExpenseTracker.Models;
using ExpenseTracker.ORM;
using ExpenseTracker.Static;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// CreditManager class performs CRUD operation with Cre01 class by using ORM ( CreditService )
    /// </summary>
    public class BLCreditManager
    {
        #region Private Members

        /// <summary>
        /// To use Credit Service 
        /// </summary>
        private CreditService _objCreditService;

        /// <summary>
        /// user id retrieved from current user context
        /// </summary>
        private int _r01f01 = Static.Static.GetUserIdFromClaims();

        /// <summary>
        /// POCO Moodel
        /// </summary>
        private Cre01 _objCre01;

        #endregion

        #region Public Members

        /// <summary>
        /// Which type of operation is performing on database 
        /// </summary>
        public Operation operation;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes necessary references to perform operations
        /// </summary>
        public BLCreditManager(Operation operation)
        {
            _objCreditService = new CreditService(MyAppDbConnectionFactory.Instance);
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
            _objCre01.e01f02 = _r01f01;
        }

        /// <summary>
        /// Validate POCO Model 
        /// </summary>
        /// <returns>true if validated else false </returns>
        public bool Validate()
        {
            // credit amount should be graeter then zero
            if (_objCre01.e01f03 <= 0)
            {
                return false;
            }

            //category of expense can't be null
            if (_objCre01.e01f04.IsNullOrEmpty())
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
        public void Save()
        {
            // Create Database Record
            if (Operation.Create == operation)
            {
                // set creation time
                _objCre01.e01f05 = DateTime.Now;
                // set updation time
                _objCre01.e01f06 = DateTime.Now;

                _objCreditService.AddCredit(_objCre01);
            }
            // Update Database Record
            else if (Operation.Update == operation)
            {
                // set updation time
                _objCre01.e01f06 = DateTime.Now;

                _objCreditService.UpdateCredit(_objCre01);
            }
            // Delete Database Record
            else if(Operation.Delete == operation)
            {
                _objCreditService.DeleteCredit(_objCre01.e01f01);
            }
        }

        /// <summary>
        /// Get all credit details for specific user
        /// </summary>
        /// <returns> List of Credit detail for that userId</returns>
        public List<DTOCre01> GetAllCredit()
        {
            List<Cre01> lstCre01 = _objCreditService.GetAllCredits(_r01f01);

            // POCO to DTO
            List<DTOCre01> lstDTOCre01 = new List<DTOCre01>();
            foreach (Cre01 objCre01 in lstCre01)
            {
                DTOCre01 objDTOCre01 = objCre01.ConvertModel<DTOCre01>();
                lstDTOCre01.Add(objDTOCre01);
            }

            return lstDTOCre01;
        }

        #region Public Members

        /// <summary>
        /// Type of operation 
        /// </summary>
        public Operation _operation;

        #endregion


        #endregion
    }
}