using System;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Class of Model - Report
    /// </summary>
    public class Rep01
    {
        #region Public Members

        /// <summary>
        /// ReportId
        /// </summary>
        [JsonPropertyName("p01101")]
        public int p01f01 { get; set; }

        /// <summary>
        /// Report
        /// </summary>
        [JsonPropertyName("p01102")]
        public string p01f02 { get; set; }

        /// <summary>
        /// Report Creation Time
        /// </summary>
        public DateTime p01f03 { get; set; }

        #endregion
    }
}