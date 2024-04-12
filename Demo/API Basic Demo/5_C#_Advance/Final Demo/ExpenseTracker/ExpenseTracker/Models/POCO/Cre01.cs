using ServiceStack.DataAnnotations;
using System;

namespace ExpenseTracker.Models.POCO
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
        public int E01f01 { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public int E01f02 { get; set; }

        /// <summary>
        /// Credit Amount
        /// </summary>
        public decimal E01f03 { get;set; }

        /// <summary>
        /// Description about Credit Amount 
        /// </summary>
        public string E01f04 { get; set; } = string.Empty;

        /// <summary>
        /// Credit Creation Time
        /// </summary>
        public DateTime E01f05 { get; set; }

        /// <summary>
        /// Credit Updation Time
        /// </summary>
        public DateTime E01f06 { get; set; }

        #endregion
    }
}