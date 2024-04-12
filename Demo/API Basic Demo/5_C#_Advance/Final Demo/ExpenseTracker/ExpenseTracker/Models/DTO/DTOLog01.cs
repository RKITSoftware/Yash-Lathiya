using Newtonsoft.Json;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Login Model consists username & password, which will user pass in login method of user controller
    /// </summary>
    public class DTOLog01
    {
        /// <summary>
        /// userid
        /// </summary>
        [JsonProperty("g01101")]
        public int g01f01 { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [JsonProperty("g01102")]
        public string g01f02 { get; set; }
    }
}