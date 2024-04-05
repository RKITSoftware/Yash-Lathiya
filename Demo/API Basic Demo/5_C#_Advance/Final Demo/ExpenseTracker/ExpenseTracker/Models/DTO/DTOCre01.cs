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
        [JsonPropertyName("e01f01")]
        public int e01101 { get; set; }

        /// <summary>
        /// Credit Amount
        /// </summary>
        [JsonPropertyName("e01f03")]
        public decimal e01102 { get;set; }

        /// <summary>
        /// Description about Credit Amount 
        /// </summary>
        [JsonPropertyName("e01f04")]
        public string e01103 { get; set; } = string.Empty;

        #endregion

    }
}