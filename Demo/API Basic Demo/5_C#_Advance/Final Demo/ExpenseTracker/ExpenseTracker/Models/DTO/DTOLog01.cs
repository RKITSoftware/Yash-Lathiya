using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = " user id required ")]
        [JsonProperty("G01101")]
        public int G01f01 { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [Required(ErrorMessage = " password required ")]
        [JsonProperty("G01102")]
        public string G01f02 { get; set; }
    }
}