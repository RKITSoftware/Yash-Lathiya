using Newtonsoft.Json;

namespace ExpenseTracker.Models.DTO
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
        public string R01f02 { get; set; }

        /// <summary>
        /// User Email Id
        /// </summary>
        [JsonProperty("r01102")]
        public string R01f03 { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        [JsonProperty("r01103")]
        public long R01f04 { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [JsonProperty("r0104")]
        public string R01f05 { get; set; }

        #endregion
    }
}