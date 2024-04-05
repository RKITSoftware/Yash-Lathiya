using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// DTO Model of User 
    /// </summary>
    public class DTOUsr01
    {
        #region Public Members

        /// <summary>
        /// UserName
        /// </summary>
        [JsonPropertyName("r01f02")]
        public string r01101 { get; set; }

        /// <summary>
        /// User Email Id
        /// </summary>
        [JsonPropertyName("r01f03")]
        public string r01102 { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        [JsonPropertyName("r01f04")]
        public long r01103 { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonPropertyName("r01f05")]
        public string r01104 { get; set; }

        #endregion
    }
}