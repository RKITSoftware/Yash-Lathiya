using ExpenseTracker.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Dashboard Manager inherits abstract class wallet & implements all its methods 
    /// </summary>
    public class DashboardManager : Wallet
    {
        #region Public Methods

        /// <summary>
        /// To check current balance for specified user
        /// </summary>
        /// <param name="r01f01"> User Id </param>
        /// <returns> Current Balance </returns>
        public override decimal CurrentBalance(int r01f01)
        {
            return TotalCredit(r01f01) - TotalExpense(r01f01);
        }

        /// <summary>
        /// To find total expense for specified user
        /// </summary>
        /// <param name="r01f01"> User Id </param>
        /// <returns> Total Expense </returns>
        public override decimal TotalExpense(int r01f01)
        {
            List<Exp01> lstExp01 = ExpenseManager.GetAllExpense(r01f01);
            
            // Calculate by LINQ
            var totalExpense = (from expense in lstExp01
                               select expense.p01f03).Sum();

            return totalExpense;
        }

        /// <summary>
        /// To find total credit for specified user
        /// </summary>
        /// <param name="r01f01"> User Id </param>
        /// <returns> Total Credit </returns>
        public override decimal TotalCredit(int r01f01)
        {
            List<Cre01> lstCre01 = CreditManager.GetAllCredit(r01f01);

            // Calculate by LINQ
            var totalExpense = (from credit in lstCre01
                                select credit.e01f03).Sum();

            return totalExpense;
        }

        #endregion
    }
}