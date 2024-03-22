using ServiceStack.DataAnnotations;

namespace Dependency_Injection.Models
{
    /// <summary>
    /// Model of Product 
    /// </summary>
    [Alias("Pro01")]
    public class Pro01
    {
        #region Public Members

        /// <summary>
        /// Id of product
        /// </summary>
        public int o01f01 { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string o01f02 { get; set; }

        /// <summary>
        /// Product Price
        /// </summary>
        public int o01f03 { get; set; }

        #endregion

    }
}
