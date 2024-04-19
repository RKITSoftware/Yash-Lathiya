using ServiceStack.DataAnnotations;
using System;

namespace ExpenseTracker.Models.POCO
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
        [PrimaryKey]
        public int P01f01 { get; set; }

        /// <summary>
        /// UserID
        /// </summary>
        public int P01f02 { get; set; }

        /// <summary>
        /// Expense Amount
        /// </summary>
        public decimal P01f03 { get; set; }

        /// <summary>
        /// Date & Time of Expense 
        /// </summary>
        [IgnoreOnInsert]
        [IgnoreOnSelect]
        [IgnoreOnUpdate]
        public DateTime P01f04 { get; set; }

        /// <summary>
        /// Category of Expense 
        /// </summary>
        public string P01f05 { get; set; } = string.Empty;

        /// <summary>
        /// Description of Expense 
        /// </summary>
        public string P01f06 { get; set; } = string.Empty;

        /// <summary>
        /// Expense Creation Time
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime P01f07 { get; set; }

        /// <summary>
        /// Expense Updation Time
        /// </summary>
        [IgnoreOnInsert]
        public DateTime P01f08 { get; set; }

        #endregion
    }
}