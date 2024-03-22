using Dependency_Injection.Interfaces;
using Dependency_Injection.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{ 
    /// <summary>
    /// Product controller 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLProduct : ControllerBase
    {
        #region Private Members

        // interface of product service 
        private readonly IProductService _productService;

        #endregion

        #region Public Members

        /// <summary>
        /// Added dependency of IProductService
        /// </summary>
        /// <param name="productService"> interface implementation </param>
        public CLProduct(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// To get all products 
        /// </summary>
        /// <returns> list of all products </returns>
        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetAllProducts([FromServices] IProductService _productService)
        {
            List<Pro01> lstPro01 = _productService.GetAllProducts();
            return Ok(lstPro01);
        }

        /// <summary>
        /// Adds a product 
        /// </summary>
        /// <param name="objPro01"> object of product </param>
        /// <returns> total product </returns>
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(Pro01 objPro01)
        {
            _productService.AddProduct(objPro01);
            return Ok("Added");
        }

        #endregion

    }
}
