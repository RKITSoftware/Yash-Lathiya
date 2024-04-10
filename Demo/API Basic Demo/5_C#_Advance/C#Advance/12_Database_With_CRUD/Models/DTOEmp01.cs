using System.Text.Json.Serialization;

namespace _12_Database_With_CRUD.Models
{
    /// <summary>
    /// DTO model of employee
    /// </summary>
    public class DTOEmp01
    {
        #region Public Members

        /// <summary>
        /// Id of Employee 
        /// </summary>
        [JsonPropertyName("p01f01")]
        public int p01101 { get; set; }

        /// <summary>
        /// Name of Employee
        /// </summary>
        [JsonPropertyName("p01f02")]
        public string p01102 { get; set; }

        /// <summary>
        /// Position of EMployee
        /// </summary>
        [JsonPropertyName("p01f03")]
        public string p01103 { get; set; }

        /// <summary>
        /// Annual Package of Employee
        /// </summary>
        [JsonPropertyName("p01f04")]
        public int p01104 { get; set; }

        #endregion
    }
}