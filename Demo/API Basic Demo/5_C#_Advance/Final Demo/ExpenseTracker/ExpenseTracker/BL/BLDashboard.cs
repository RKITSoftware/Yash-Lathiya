using ExpenseTracker.Models.POCO;
using ServiceStack.OrmLite;
using System.Linq;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Dashboard Manager inherits abstract class wallet & implements all its methods 
    /// </summary>
    public class BLDashboard : IWallet
    {
        #region Public Methods

        /// <summary>
        /// To check current balance for specified user
        /// </summary>
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
            decimal totalExpense = 0;

            using(var db = Common.OrmContext.OpenDbConnection())
            {
                totalExpense = db.Select<Exp01>(exp => exp.P01f02 == Common.GetUserIdFromClaims()).Sum(exp => exp.P01f03);  
            }

            return totalExpense;
        }

        /// <summary>
        /// To find total credit for specified user
        /// </summary>
        /// <returns> Total Credit </returns>
        public decimal TotalCredit()
        {
            decimal totalCredit = 0;

            using (var db = Common.OrmContext.OpenDbConnection())
            {
                totalCredit = db.Select<Cre01>(cre => cre.E01f02 == Common.GetUserIdFromClaims()).Sum(cre => cre.E01f03);
            }

            return totalCredit;
        }

        #endregion
    }
}