﻿using ExpenseTracker.Models;
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

        // To use Credit Service 
        private CreditService _objCreditService;

        // user id retrieved from current user context
        private int _r01f01 = Static.Static.GetUserIdFromClaims();

        // POCO Moodel
        private Cre01 _objCre01;

        #endregion

        #region Public Members

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
        public void Save(Operation op)
        {
            // Create Database Record
            if (Operation.Create == op)
            {
                // set creation time
                _objCre01.e01f05 = DateTime.Now;
                // set updation time
                _objCre01.e01f06 = DateTime.Now;

                _objCreditService = new CreditService(MyAppDbConnectionFactory.Instance);
                _objCreditService.AddCredit(_objCre01);
            }
            // Update Database Record
            else if (Operation.Update == op)
            {
                // set updation time
                _objCre01.e01f06 = DateTime.Now;

                _objCreditService = new CreditService(MyAppDbConnectionFactory.Instance);
                _objCreditService.UpdateCredit(_objCre01);
            }
        }

        /// <summary>
        /// Get all credit details for specific user
        /// </summary>
        /// <returns> List of Credit detail for that userId</returns>
        public List<DTOCre01> GetAllCredit()
        {
            _objCreditService = new CreditService(MyAppDbConnectionFactory.Instance);
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

        /// <summary>
        /// Delete credit detail from the database
        /// </summary>
        /// <param name="e01101"> Credit Id </param>
        public void DeleteCredit(int e01101)
        {
            _objCreditService = new CreditService(MyAppDbConnectionFactory.Instance);
            _objCreditService.DeleteCredit(e01101);
        }

        #endregion
    }
}