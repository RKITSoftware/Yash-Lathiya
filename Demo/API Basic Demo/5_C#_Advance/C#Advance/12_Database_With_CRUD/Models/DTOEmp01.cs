using Newtonsoft.Json;

namespace _12_Database_With_CRUD.Models
{
    /// <summary>
    /// DTO model of Emp01
    /// </summary>
    public class DTOEmp01
    {
        #region Public Members

        /// <summary>
        /// Id of Emp01 
        /// </summary>
        [JsonProperty("p01101")]
        public int P01f01 { get; set; }

        /// <summary>
        /// Name of Emp01
        /// </summary>
        [JsonProperty("p01102")]
        public string P01f02 { get; set; }

        /// <summary>
        /// Position of Emp01
        /// </summary>
        [JsonProperty("p01103")]
        public string P01f03 { get; set; }

        /// <summary>
        /// Annual Package of Emp01
        /// </summary>
        [JsonProperty("p01104")]
        public int P01f04 { get; set; }

        #endregion
    }
}