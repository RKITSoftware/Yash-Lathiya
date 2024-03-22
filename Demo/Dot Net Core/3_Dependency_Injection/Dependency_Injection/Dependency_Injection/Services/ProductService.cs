using Dependency_Injection.Interfaces;
using Dependency_Injection.Models;

namespace Dependency_Injection.Services
{
    /// <summary>
    /// Implements IproductService interface 
    /// Maintains lstProduct 
    /// also provides method of add and GetAll for products
    /// </summary>
    public class ProductService : IProductService
    {
        #region Private Members 

        private List<Pro01> lstProduct = new List<Pro01>();

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds product in lstProduct 
        /// </summary>
        /// <param name="objPro01"> object of product</param>
        public void AddProduct(Pro01 objPro01)
        {
            objPro01.o01f01 = lstProduct.Count + 1;
            lstProduct.Add(objPro01);
        }

        /// <summary>
        /// Get all products in lstProduct 
        /// </summary>
        /// <returns> list of products </returns>
        public List<Pro01> GetAllProducts()
        {
            return lstProduct;
        }

        #endregion

    }
}
