using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Model of Expense
    /// </summary>
    [Alias("exp01")]
    public class Exp01
    {
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
        public DateTime p01f04 { get; set; } = DateTime.Now;

        /// <summary>
        /// Category of Expense 
        /// </summary>
        public string p01f05 { get; set; } = string.Empty;

        /// <summary>
        /// Description of Expense 
        /// </summary>
        public string p01f06 { get; set; } = string.Empty;
    }
}