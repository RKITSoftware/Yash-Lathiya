using System;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Model of User 
    /// </summary>
    public class Usr01
    {
        #region Public Members

        /// <summary>
        /// User Id
        /// </summary>
        public int r01f01 { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        [JsonPropertyName("r01101")]
        public string r01f02 { get; set; }

        /// <summary>
        /// User Email Id
        /// </summary>
        [JsonPropertyName("r01102")]
        public string r01f03 { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        [JsonPropertyName("r01103")]
        public long r01f04 { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonPropertyName("r01104")]
        public string r01f05 { get; set; }

        /// <summary>
        /// User Creation Time
        /// </summary>
        public DateTime r01f06 { get; set; }

        /// <summary>
        /// User Updation Time
        /// </summary>
        public DateTime r01f07 { get; set; }

        #endregion
    }
}