using ServiceStack.DataAnnotations;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Class of Model - Credit 
    /// </summary>
    [Alias("cre01")]
    public class Cre01
    {
        #region Public Members

        /// <summary>
        /// Credit Id
        /// </summary>
        public int e01f01 { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public int e01f02 { get; set; }

        /// <summary>
        /// Credit Amount
        /// </summary>
        public decimal e01f03 { get;set; }

        /// <summary>
        /// Description about Credit Amount 
        /// </summary>
        public string e01f04 { get; set; } = string.Empty;

        #endregion
    }
}