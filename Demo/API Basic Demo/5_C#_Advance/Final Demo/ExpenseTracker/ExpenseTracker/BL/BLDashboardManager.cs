using ExpenseTracker.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Dashboard Manager inherits abstract class wallet & implements all its methods 
    /// </summary>
    public class BLDashboardManager : IWallet
    {
        #region Public Methods

        /// <summary>
        /// To check current balance for specified user
        /// </summary>
        /// <param name="r01f01"> User Id </param>
        /// <returns> Current Balance </returns>
        public decimal CurrentBalance()
        {
            return TotalCredit() - TotalExpense();
        }

        /// <summary>
        /// To find total expense for specified user
        /// </summary>
        /// <returns> Total Expense </returns>
        public decimal TotalExpense()
        {
            BLExp01 objBLExpenseManager = new BLExp01();
            List<DTOExp01> lstDTOExp01 = objBLExpenseManager.GetAllExpense();
            
            // Calculate by LINQ
            var totalExpense = (from expense in lstDTOExp01
                               select expense.p01102).Sum();

            return totalExpense;
        }

        /// <summary>
        /// To find total credit for specified user
        /// </summary>
        /// <returns> Total Credit </returns>
        public decimal TotalCredit()
        {
            BLCre01 objBLCreditManager = new BLCre01();
            List<DTOCre01> lstDTOCre01 = objBLCreditManager.GetAllCredit();

            // Calculate by LINQ
            var totalExpense = (from credit in lstDTOCre01
                                select credit.e01102).Sum();

            return totalExpense;
        }

        #endregion
    }
}