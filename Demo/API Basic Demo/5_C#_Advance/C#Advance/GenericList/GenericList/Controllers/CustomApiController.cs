using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenericList.Controllers
{
    public class CustomApiController : ApiController
    {
        ProductController productController;

        public CustomApiController()
        {
            this.productController = new ProductController();
        }
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            return productController.GetAllEntities();
        }
    }
}
