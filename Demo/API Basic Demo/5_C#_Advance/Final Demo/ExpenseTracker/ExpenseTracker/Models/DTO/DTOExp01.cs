using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models.DTO
{
    /// <summary>
    /// DTO Model of Expense
    /// </summary>
    public class DTOExp01
    {
        #region Public Members

        /// <summary>
        /// Expense Id 
        /// </summary>
        [Required(ErrorMessage = " expense id required ")]
        [Range(0, int.MaxValue, ErrorMessage = " invalid expense id ")]
        [JsonProperty("p01101")]
        public int P01f01 { get; set; }

        /// <summary>
        /// Expense Amount
        /// </summary>
        [Required(ErrorMessage = " expense amount required ")]
        [Range(0, double.MaxValue, ErrorMessage = " invalid expense id ")]
        [JsonProperty("p01102")]
        public decimal P01f03 { get; set; }

        /// <summary>
        /// Category of Expense 
        /// </summary>
        [Required(ErrorMessage = " category of response required ")]
        [JsonProperty("p01103")]
        public string P01f05 { get; set; } = string.Empty;

        /// <summary>
        /// Description of Expense 
        /// </summary>
        [JsonProperty("p01104")]
        public string P01f06 { get; set; } = string.Empty;

        #endregion
    }
}