using _1_Types_of_Class.Class.Sealed_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1_Types_of_Class.Controllers
{
    /// <summary>
    /// Demonstrates implementation of sealed class
    /// </summary>
    public class CLSealedClassController : ApiController
    {
        #region Public Methods

        /// <summary>
        /// Demonstrated use of sealed class
        /// </summary>
        /// <returns> Protected Method Detail </returns>
        [HttpGet]
        [Route("SealedClass/MethodDetail")]
        public IHttpActionResult MethodDetail()
        {
            SealedClass sealedClass = new SealedClass();

            return Ok(sealedClass.ProtectedMethod());
        }

        #endregion
    }
}
