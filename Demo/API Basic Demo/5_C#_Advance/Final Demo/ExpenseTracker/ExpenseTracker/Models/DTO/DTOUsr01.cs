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
        [Required(ErrorMessage = " username required ")]
        [JsonProperty("r01101")]
        public string R01f02 { get; set; }

        /// <summary>
        /// User Email Id
        /// </summary>
        [Required(ErrorMessage = " email id required ")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = " invalid email id ")]
        [JsonProperty("r01102")]
        public string R01f03 { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        [Required(ErrorMessage = " mobile number required ")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = " invalid mobile number ")]
        [JsonProperty("r01103")]
        public long R01f04 { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = " password required ")]
        [JsonProperty("r0104")]
        public string R01f05 { get; set; }

        #endregion
    }
}