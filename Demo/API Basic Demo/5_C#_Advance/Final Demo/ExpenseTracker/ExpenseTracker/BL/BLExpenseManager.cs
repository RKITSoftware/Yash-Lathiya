using ExpenseTracker.Models;
using ExpenseTracker.ORM;
using ExpenseTracker.Static;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Consist Buisness Logic of all methods related to Expense
    /// </summary>
    public class BLExpenseManager
    {
        #region Private Members

        /// <summary>
        /// To use Expense Service 
        /// </summary>
        private ExpenseService _objExpenseService;

        /// <summary>
        /// user id retrieved from current user context
        /// </summary>
        private int _r01f01 = Static.Static.GetUserIdFromClaims();

        /// <summary>
        /// POCO Moodel
        /// </summary>
        private Exp01 _objExp01;

        #endregion

        #region Public Methods 

        /// <summary>
        /// Convert DTO model to POCO Model 
        /// </summary>
        /// <param name="objDTOExp01"></param>
        public void Presave(DTOExp01 objDTOExp01)
        {
            _objExp01 = objDTOExp01.ConvertModel<Exp01>();

            // set userid 
            _objExp01.p01f02 = _r01f01;
        }

        /// <summary>
        /// Validate POCO Model 
        /// </summary>
        /// <returns>true if validated else false </returns>
        public bool Validate()
        {
            // expense amount should be graeter then zero
            if(_objExp01.p01f03 <= 0)
            {
                return false;
            }

            // date should not be of future 
            if (_objExp01.p01f04 >= DateTime.Now)
            {
                return false;
            }

            //category of expense can't be null
            if (_objExp01.p01f05.IsNullOrEmpty())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Add or update expense in database as per operation 
        /// </summary>
        /// <param name="opeartion"> Create => Create database record
        ///                          Update  => Update database record
        /// </param>
        public void Save(Operation op)
        {
            // Create Database Record
            if (Operation.Create == op)
            {
                // set expense time
                _objExp01.p01f04 = DateTime.Now;
                // set creation time
                _objExp01.p01f07 = DateTime.Now;
                // set updation time
                _objExp01.p01f08 = DateTime.Now;

                _objExpenseService = new ExpenseService(MyAppDbConnectionFactory.Instance);
                _objExpenseService.AddExpense(_objExp01);
            }
            // Update Database Record
            else if(Operation.Update == op)
            {
                // set updation time
                _objExp01.p01f08 = DateTime.Now;

                _objExpenseService = new ExpenseService(MyAppDbConnectionFactory.Instance);
                _objExpenseService.UpdateExpense(_objExp01);
            }
        }

        /// <summary>
        /// Get expenses performed at specific UserId & DateTime
        /// </summary>
        /// <param name="p01f04"> Expense Date </param>
        /// <returns> List of all expenses satisfies condition </returns>
        public List<DTOExp01> GetExpense(DateTime p01f04)
        {
            _objExpenseService = new ExpenseService(MyAppDbConnectionFactory.Instance);
            List<Exp01> lstExp01 = _objExpenseService.GetExpense(_r01f01, p01f04);

            // POCO to DTO
            List<DTOExp01> lstDTOExp01 = new List<DTOExp01>();
            foreach (Exp01 objExp01 in lstExp01)
            {
                DTOExp01 objDTOExp01 = objExp01.ConvertModel<DTOExp01>();
                lstDTOExp01.Add(objDTOExp01);
            }

            return lstDTOExp01;
        }

        /// <summary>
        /// Get all expenses for specific User
        /// </summary>
        /// <returns>List of all expenses for specific user </returns>
        public List<DTOExp01> GetAllExpense()
        {
            _objExpenseService = new ExpenseService(MyAppDbConnectionFactory.Instance);
            List<Exp01> lstExp01 = _objExpenseService.GetAllExpense(_r01f01);

            // POCO to DTO
            List<DTOExp01> lstDTOExp01 = new List<DTOExp01>();
            foreach(Exp01 objExp01 in lstExp01)
            {
                DTOExp01 objDTOExp01 = objExp01.ConvertModel<DTOExp01>();
                lstDTOExp01.Add(objDTOExp01);
            }

            return lstDTOExp01;
        }

        /// <summary>
        /// To delete expense from the database 
        /// </summary>
        /// <param name="p01f01"> Expense Id </param>
        public void DeleteExpense(int p01f01)
        {
            _objExpenseService = new ExpenseService(MyAppDbConnectionFactory.Instance);
            _objExpenseService.DeleteExpense(p01f01);
        }

        #endregion

    }
}