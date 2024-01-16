using _1_Types_of_Class.Class.Static_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1_Types_of_Class.Controllers
{
    /// <summary>
    /// Demonstration of static class
    /// </summary>
    public class CLStaticClassController : ApiController
    {
        #region Public Methods

        /// <summary>
        /// Method of static class can be directly used.
        /// There is no need to create instance of static class.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("StaticClass/greeting")]
        public IHttpActionResult Greeting()
        {
            // Static class can not be instiated

            //try
            //{
            //    StaticClass staticClass = new StaticClass();
            //    return Ok(staticClass.Greetings());
            //}

            return Ok(StaticClass.Greetings("Yash Lathiya"));
        }

        #endregion
    }
}
