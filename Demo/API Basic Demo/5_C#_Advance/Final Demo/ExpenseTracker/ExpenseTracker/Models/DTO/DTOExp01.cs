using Newtonsoft.Json;

namespace ExpenseTracker.Models
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
        [JsonProperty("p01101")]
        public int p01f01 { get; set; }

        /// <summary>
        /// Expense Amount
        /// </summary>
        [JsonProperty("p01102")]
        public decimal p01f03 { get; set; }

        /// <summary>
        /// Category of Expense 
        /// </summary>
        [JsonProperty("p01103")]
        public string p01f05 { get; set; } = string.Empty;

        /// <summary>
        /// Description of Expense 
        /// </summary>
        [JsonProperty("p01104")]
        public string p01f06 { get; set; } = string.Empty;

        #endregion
    }
}