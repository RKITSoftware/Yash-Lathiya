using Newtonsoft.Json;

namespace ExpenseTracker.Models.DTO
{
    /// <summary>
    /// Login Model consists username & password, which will user pass in login method of user controller
    /// </summary>
    public class DTOLog01
    {
        /// <summary>
        /// userid
        /// </summary>
        [JsonProperty("G01101")]
        public int G01f01 { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [JsonProperty("G01102")]
        public string G01f02 { get; set; }
    }
}