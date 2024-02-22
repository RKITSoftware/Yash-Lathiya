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
        /// <param name="r01f01"> User Id </param>
        /// <returns> Current Balance</returns>
        public abstract decimal CurrentBalance(int r01f01);

        /// <summary>
        /// Total Expense for specific user
        /// </summary>
        /// <param name="r01f01"> User Id </param>
        /// <returns> Total Expense </returns>
        public abstract decimal TotalExpense(int r01f01);

        /// <summary>
        /// Total Credit for specific user
        /// </summary>
        /// <param name="r01f01"> USer Id </param>
        /// <returns> Total Credit </returns>
        public abstract decimal TotalCredit(int r01f01);
    }
}