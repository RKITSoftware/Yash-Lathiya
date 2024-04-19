using ExpenseTracker.Models;
using ExpenseTracker.Models.POCO;
using ServiceStack.OrmLite;
using System.Data;
using System.Linq;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Dashboard Manager inherits abstract class wallet & implements all its methods 
    /// </summary>
    public class BLDashboardHandler : IWallet
    {
        #region Private Members

        /// <summary>
        /// Response of HTTP Action Method
        /// </summary>
        private readonly Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes object of response 
        /// </summary>
        public BLDashboardHandler()
        {
            _objResponse = new Response();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To check current balance for specified user
        /// </summary>
        /// <returns> Current Balance </returns>
        public Response CurrentBalance()
        {
            DataTable dtCurrentBalance = new DataTable();
            dtCurrentBalance.Columns.Add("CurrentBalance", typeof(decimal));
            dtCurrentBalance.Rows.Add((decimal)TotalCredit().Data.Rows[0]["TotalCredit"] - (decimal)TotalExpense().Data.Rows[0]["TotalExpense"]);

            _objResponse.SetResponse(" Current Balance ", dtCurrentBalance);

            return _objResponse;
        }

        /// <summary>
        /// To find total expense for specified user
        /// </summary>
        /// <returns> Total Expense </returns>
        public Response TotalExpense()
        {
            decimal totalExpense = 0;

            using(var db = Common.OrmContext.OpenDbConnection())
            {
                totalExpense = db.Select<Exp01>(exp => exp.P01f02 == Common.GetUserIdFromClaims()).Sum(exp => exp.P01f03);  
            }

            DataTable dtExp01Total = new DataTable();
            dtExp01Total.Columns.Add("TotalExpense", typeof(decimal));
            dtExp01Total.Rows.Add(totalExpense);

            _objResponse.SetResponse(" Total Expense ", dtExp01Total);

            return _objResponse;
        }

        /// <summary>
        /// To find total credit for specified user
        /// </summary>
        /// <returns> Total Credit </returns>
        public Response TotalCredit()
        {
            decimal totalCredit = 0;

            using (var db = Common.OrmContext.OpenDbConnection())
            {
                totalCredit = db.Select<Cre01>(cre => cre.E01f02 == Common.GetUserIdFromClaims()).Sum(cre => cre.E01f03);
            }

            DataTable dtCre01Total = new DataTable();
            dtCre01Total.Columns.Add("TotalCredit", typeof(decimal));
            dtCre01Total.Rows.Add(totalCredit);

            _objResponse.SetResponse(" Total Credit ", dtCre01Total);

            return _objResponse;
        }

        #endregion
    }
}