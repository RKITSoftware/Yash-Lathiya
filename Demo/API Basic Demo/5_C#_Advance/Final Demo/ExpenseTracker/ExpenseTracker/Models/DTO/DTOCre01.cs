using Newtonsoft.Json;

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
        [JsonProperty("e01101")]
        public int E01f01 { get; set; }

        /// <summary>
        /// Credit Amount
        /// </summary>
        [JsonProperty("e01102")]
        public decimal E01f03 { get;set; }

        /// <summary>
        /// Description about Credit Amount 
        /// </summary>
        [JsonProperty("e01103")]
        public string E01f04 { get; set; } = string.Empty;

        #endregion

    }
}