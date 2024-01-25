using _2_Generics.Generics;
using System;
using System.Web.Http;

namespace _2_Generics.Controllers
{
    /// <summary>
    /// Api controller demonstrates generic controller, generic class & generic method's implementation
    /// </summary>
    public class CLApiController : ApiController
    {
        #region Public Methods

        /// <summary>
        /// From Generic Controller
        /// </summary>
        /// <returns> Confidential Information </returns>
        [HttpGet]
        [Route("api/GenericController")]
        public IHttpActionResult UsingGenericController()
        {
            CLGenericController<string> information = new CLGenericController<string>();

            return Ok(information.GetInformation("This is Confidential Information"));
        }

        /// <summary>
        /// From Generic Class
        /// </summary>
        /// <returns> User Details </returns>
        [HttpGet]
        [Route("api/FromGenericClass")]
        public IHttpActionResult GetInfoFromGenericClass()
        {
            Console.WriteLine("Login Detected");
            GenericClass<string> name = new GenericClass<string>("Yash");
            GenericClass<int> id = new GenericClass<int>(1001);
            GenericClass<bool> superAdmin = new GenericClass<bool>(false);

            return Ok(new
            {
                Message = "Login Detected -> Details in Output tab",
            });
        }

        /// <summary>
        /// From Generic Method
        /// </summary>
        /// <returns> User Details </returns>
        [HttpGet]
        [Route("api/FromGenericMethod")]
        public IHttpActionResult GetInfoFromGenericMethod()
        {
            GenericMethod genericClass = new GenericMethod();

            return Ok(new
            {
                Message = "Login Detected",
                Name = genericClass.GenericMethodOfClass<string>("Sachin"),
                id = genericClass.GenericMethodOfClass<int>(1002),
                superAdmin = genericClass.GenericMethodOfClass<bool>(false)
            });
        }

        #endregion
    }
}
