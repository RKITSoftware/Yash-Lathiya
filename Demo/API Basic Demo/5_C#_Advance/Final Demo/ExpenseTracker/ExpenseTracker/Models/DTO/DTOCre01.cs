using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ExpenseTracker.Models
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
        [JsonProperty("e01101")]
        public int e01f01 { get; set; }

        /// <summary>
        /// Credit Amount
        /// </summary>
        [JsonProperty("e01102")]
        public decimal e01f03 { get;set; }

        /// <summary>
        /// Description about Credit Amount 
        /// </summary>
        [JsonProperty("e01103")]
        public string e01f04 { get; set; } = string.Empty;

        #endregion

    }
}