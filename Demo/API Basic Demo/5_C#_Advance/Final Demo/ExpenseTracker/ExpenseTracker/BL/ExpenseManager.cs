using ExpenseTracker.Models;
using ExpenseTracker.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Consist Buisness Logic of all methods related to Expense
    /// </summary>
    public static class ExpenseManager
    {
        #region Static Members

        // To use Expense Service 
        private static ExpenseService objExpenseService;
        // To assign dbFactory
        static ExpenseManager()
        {
            objExpenseService = new ExpenseService(MyAppDbConnectionFactory.Instance);
        }

        #endregion

        #region Public Methods 

        /// <summary>
        /// Add Expense in table Exp01 database
        /// </summary>
        /// <param name="objExp01"> Object of Expense </param>
        public static void AddExpense( Exp01 objExp01)
        {
            objExpenseService.AddExpense(objExp01); 
        }

        /// <summary>
        /// Get expenses performed at specific UserId & DateTime
        /// </summary>
        /// <param name="p01f02"> User Id </param>
        /// <param name="p01f04"> Expense Date </param>
        /// <returns> List of all expenses satisfies condition </returns>
        public static List<Exp01> GetExpense(int p01f02, DateTime p01f04)
        {
            return objExpenseService.GetExpense(p01f02, p01f04);
        }

        /// <summary>
        /// Get all expenses for specific User
        /// </summary>
        /// <param name="p01f02"> UserId </param>
        /// <returns>List of all expenses for specific user </returns>
        public static List<Exp01> GetAllExpense(int p01f02)
        {
            return objExpenseService.GetAllExpense(p01f02);
        }

        /// <summary>
        /// Update expense in the database
        /// </summary>
        /// <param name="objExp01"> Object of Expense </param>
        public static void UpdateExpense(Exp01 objExp01)
        {
            objExpenseService.UpdateExpense(objExp01);
        }

        /// <summary>
        /// To delete expense from the database 
        /// </summary>
        /// <param name="p01f01"> Expense Id </param>
        public static void DeleteExpense(int p01f01)
        {
            objExpenseService.DeleteExpense(p01f01);
        }

        #endregion

    }
}