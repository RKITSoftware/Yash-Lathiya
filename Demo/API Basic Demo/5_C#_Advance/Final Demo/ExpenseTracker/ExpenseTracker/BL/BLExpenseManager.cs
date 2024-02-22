using ExpenseTracker.Models;
using ExpenseTracker.ORM;
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

        // To use Expense Service 
        private ExpenseService objExpenseService;

        // user id retrieved from current user context
        private int _r01f01 = Static.Static.GetUserIdFromClaims();

        #endregion

        #region Public Members 

        // To assign dbFactory
        public BLExpenseManager()
        {
            objExpenseService = new ExpenseService(MyAppDbConnectionFactory.Instance);
        }

        /// <summary>
        /// Add Expense in table Exp01 database
        /// </summary>
        /// <param name="objExp01"> Object of Expense </param>
        public void AddExpense( Exp01 objExp01)
        {
            objExp01.p01f02 = _r01f01;
            objExpenseService.AddExpense(objExp01); 
        }

        /// <summary>
        /// Get expenses performed at specific UserId & DateTime
        /// </summary>
        /// <param name="p01f04"> Expense Date </param>
        /// <returns> List of all expenses satisfies condition </returns>
        public List<Exp01> GetExpense(DateTime p01f04)
        {
            return objExpenseService.GetExpense(_r01f01, p01f04);
        }

        /// <summary>
        /// Get all expenses for specific User
        /// </summary>
        /// <returns>List of all expenses for specific user </returns>
        public List<Exp01> GetAllExpense()
        {
            return objExpenseService.GetAllExpense(_r01f01);
        }

        /// <summary>
        /// Update expense in the database
        /// </summary>
        /// <param name="objExp01"> Object of Expense </param>
        public void UpdateExpense(Exp01 objExp01)
        {
            objExp01.p01f02 = _r01f01;
            objExpenseService.UpdateExpense(objExp01);
        }

        /// <summary>
        /// To delete expense from the database 
        /// </summary>
        /// <param name="p01f01"> Expense Id </param>
        public void DeleteExpense(int p01f01)
        {
            objExpenseService.DeleteExpense(p01f01);
        }

        #endregion

    }
}