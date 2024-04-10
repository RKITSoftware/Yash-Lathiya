using System;
using System.Text.Json.Serialization;

namespace _12_Database_With_CRUD.Models
{
    /// <summary>
    /// Class of Model - Employee
    /// </summary>
    public class Emp01
    {
        #region Public Members

        /// <summary>
        /// Id of Employee 
        /// </summary>
        [JsonPropertyName("p01101")]
        public int p01f01 { get; set; }

        /// <summary>
        /// Name of Employee
        /// </summary>
        [JsonPropertyName("p01102")]
        public string p01f02 { get; set; }

        /// <summary>
        /// Position of EMployee
        /// </summary>
        [JsonPropertyName("p01103")]
        public string p01f03 { get; set; }

        /// <summary>
        /// Annual Package of Employee
        /// </summary>
        [JsonPropertyName("p01104")]
        public int p01f04 { get; set; }

        /// <summary>
        /// Created on
        /// </summary>
        public DateTime p01f05 { get; set; }

        /// <summary>
        /// Updated on
        /// </summary>
        public DateTime p01f06 { get; set; }

        #endregion
    }
}