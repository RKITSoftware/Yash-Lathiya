using Newtonsoft.Json;

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
        [JsonProperty("r01101")]
        public string r01f02 { get; set; }

        /// <summary>
        /// User Email Id
        /// </summary>
        [JsonProperty("r01102")]
        public string r01f03 { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        [JsonProperty("r01103")]
        public long r01f04 { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonProperty("r0104")]
        public string r01f05 { get; set; }

        #endregion
    }
}