// This is the functionality of accessing ProductController & UserController from here.
// It's not running smoothly, that's why commented.
// DI is the approach which maybe solve it.

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace GenericList.Controllers
//{
//    public class CustomApiController : ApiController
//    {
//        ProductController productController;

//        public CustomApiController()
//        {
//            this.productController = new ProductController();
//        }
//        [HttpGet]
//        public IHttpActionResult GetAllProducts()
//        {
//            return productController.GetAllEntities();
//        }
//    }
//}
