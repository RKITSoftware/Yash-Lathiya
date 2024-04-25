using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Username required")]
        [JsonProperty("r01101")]
        public string R01f02 { get; set; }

        /// <summary>
        /// User Email Id
        /// </summary>
        [Required(ErrorMessage = "Email id required ")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email id ")]
        [JsonProperty("r01102")]
        public string R01f03 { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        [Required(ErrorMessage = "Mobile number required ")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid mobile number")]
        [JsonProperty("r01103")]
        public long R01f04 { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Password required")]
        [JsonProperty("r01104")]
        public string R01f05 { get; set; }

        #endregion
    }
}