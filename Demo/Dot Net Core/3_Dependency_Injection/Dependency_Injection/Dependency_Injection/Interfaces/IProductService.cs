using Dependency_Injection.Models;

namespace Dependency_Injection.Interfaces
{
    /// <summary>
    /// Interface of ProductService
    /// </summary>
    public interface IProductService
    {
        #region Public Methods

        /// <summary>
        /// Add product 
        /// </summary>
        /// <param name="objPro01"> object of product </param>
        public abstract void AddProduct(Pro01 objPro01);

        /// <summary>
        /// To get all products 
        /// </summary>
        /// <returns> List of all products </returns>
        public abstract List<Pro01> GetAllProducts();

        #endregion

    }
}
