namespace ExpenseTracker.BL
{
    /// <summary>
    /// Eallet is abstract class which consists all methods of Wallet
    /// </summary>
    public interface IWallet
    {
        /// <summary>
        /// Current Balance = Total Credit - Total Expense
        /// </summary>
        /// <returns> Current Balance</returns>
        decimal CurrentBalance();

        /// <summary>
        /// Total Expense for specific user
        /// </summary>
        /// <returns> Total Expense </returns>
        decimal TotalExpense();

        /// <summary>
        /// Total Credit for specific user
        /// </summary>
        /// <returns> Total Credit </returns>
        decimal TotalCredit();
    }
}