using ServiceStack.DataAnnotations;
using System;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("e01101")]
        public int e01f01 { get; set; }

        /// <summary>
        /// User Id
        /// </summary>
        public int e01f02 { get; set; }

        /// <summary>
        /// Credit Amount
        /// </summary>
        [JsonPropertyName("e01102")]
        public decimal e01f03 { get;set; }

        /// <summary>
        /// Description about Credit Amount 
        /// </summary>
        [JsonPropertyName("e01103")]
        public string e01f04 { get; set; } = string.Empty;

        /// <summary>
        /// Credit Creation Time
        /// </summary>
        public DateTime e01f05 { get; set; }

        /// <summary>
        /// Credit Updation Time
        /// </summary>
        public DateTime e01f06 { get; set; }

        #endregion
    }
}