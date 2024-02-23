namespace ExpenseTracker.BL
{
    /// <summary>
    /// Eallet is abstract class which consists all methods of Wallet
    /// </summary>
    public abstract class BLWallet
    {
        /// <summary>
        /// Current Balance = Total Credit - Total Expense
        /// </summary>
        /// <returns> Current Balance</returns>
        public abstract decimal CurrentBalance();

        /// <summary>
        /// Total Expense for specific user
        /// </summary>
        /// <returns> Total Expense </returns>
        public abstract decimal TotalExpense();

        /// <summary>
        /// Total Credit for specific user
        /// </summary>
        /// <returns> Total Credit </returns>
        public abstract decimal TotalCredit();
    }
}