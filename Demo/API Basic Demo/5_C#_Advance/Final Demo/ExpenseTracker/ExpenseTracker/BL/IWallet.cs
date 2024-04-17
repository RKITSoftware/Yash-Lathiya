using ExpenseTracker.Models;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Eallet is abstract class which consists all methods of Wallet
    /// </summary>
    public interface IWallet
    {
        #region Public Members

        /// <summary>
        /// Current Balance = Total Credit - Total Expense
        /// </summary>
        /// <returns> object of response </returns>
        Response CurrentBalance();

        /// <summary>
        /// Total Expense for specific user
        /// </summary>
        /// <returns> object of response </returns>
        Response TotalExpense();

        /// <summary>
        /// Total Credit for specific user
        /// </summary>
        /// <returns> object of response </returns>
        Response TotalCredit();

        #endregion
    }
}