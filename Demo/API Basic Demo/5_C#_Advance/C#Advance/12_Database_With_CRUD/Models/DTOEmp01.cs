using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [Range(0, int.MaxValue)]
        public int P01f01 { get; set; }

        /// <summary>
        /// Name of Emp01
        /// </summary>
        [JsonProperty("p01102")]
        [Required(ErrorMessage = "Employee name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Employee name must contain only letters")]
        public string P01f02 { get; set; }

        /// <summary>
        /// Position of Emp01
        /// </summary>
        [JsonProperty("p01103")]
        [Required(ErrorMessage = "Employee position is required")]
        public string P01f03 { get; set; }

        /// <summary>
        /// Annual Package of Emp01
        /// </summary>
        [JsonProperty("p01104")]
        [Required(ErrorMessage = "Annual package is required")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Annual package must be a number")]
        public int P01f04 { get; set; }

        #endregion
    }
}