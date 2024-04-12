using ServiceStack.DataAnnotations;
using System;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Model of Expense
    /// </summary>
    [Alias("exp01")]
    public class Exp01
    {
        #region Public Members

        /// <summary>
        /// Expense Id 
        /// </summary>
        public int p01f01 { get; set; }

        /// <summary>
        /// UserID
        /// </summary>
        public int p01f02 { get; set; }

        /// <summary>
        /// Expense Amount
        /// </summary>
        public decimal p01f03 { get; set; }

        /// <summary>
        /// Date & Time of Expense 
        /// </summary>
        public DateTime p01f04 { get; set; }

        /// <summary>
        /// Category of Expense 
        /// </summary>
        public string p01f05 { get; set; } = string.Empty;

        /// <summary>
        /// Description of Expense 
        /// </summary>
        public string p01f06 { get; set; } = string.Empty;

        /// <summary>
        /// Expense Creation Time
        /// </summary>
        public DateTime p01f07 { get; set; }

        /// <summary>
        /// Expense Updation Time
        /// </summary>
        public DateTime p01f08 { get; set; }

        #endregion
    }
}