using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models.DTO
{
    /// <summary>
    /// Class of DTOModel - Credit 
    /// </summary>
    public class DTOCre01
    {
        #region Public Members

        /// <summary>
        /// Credit Id
        /// </summary>
        [Required(ErrorMessage = " credit id required ")]
        [Range(0, int.MaxValue, ErrorMessage = " invalid credit id ")]
        [JsonProperty("e01101")]
        public int E01f01 { get; set; }

        /// <summary>
        /// Credit Amount
        /// </summary>
        [Required(ErrorMessage = " credit id required ")]
        [Range(0, double.MaxValue, ErrorMessage = " invalid credit amount ")]
        [JsonProperty("e01102")]
        public decimal E01f03 { get;set; }

        /// <summary>
        /// Description about Credit Amount 
        /// </summary>
        [Required(ErrorMessage = " description of credit required ")]
        [JsonProperty("e01103")]
        public string E01f04 { get; set; } = string.Empty;

        #endregion

    }
}