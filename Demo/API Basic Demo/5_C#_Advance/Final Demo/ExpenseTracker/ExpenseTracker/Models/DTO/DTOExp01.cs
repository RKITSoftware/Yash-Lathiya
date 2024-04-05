using System;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// DTO Model of Expense
    /// </summary>
    public class DTOExp01
    {
        #region Public Members

        /// <summary>
        /// Expense Id 
        /// </summary>
        [JsonPropertyName("p01f01")]
        public int p01101 { get; set; }

        /// <summary>
        /// Expense Amount
        /// </summary>
        [JsonPropertyName("p01f03")]
        public decimal p01102 { get; set; }

        /// <summary>
        /// Category of Expense 
        /// </summary>
        [JsonPropertyName("p01f05")]
        public string p01103 { get; set; } = string.Empty;

        /// <summary>
        /// Description of Expense 
        /// </summary>
        [JsonPropertyName("p01f06")]
        public string p01104 { get; set; } = string.Empty;

        #endregion
    }
}