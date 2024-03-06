using Caching.BL;
using Caching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Caching.Controllers
{
    /// <summary>
    /// Caching with help of redis
    /// </summary>
    public class CLRedisController : ApiController
    {
        // Instance of BLCaching
        private readonly BLRedis _objBlRedis;

        /// <summary>
        /// initialized instance of BLRedis class
        /// </summary>
        public CLRedisController()
        {
            _objBlRedis = new BLRedis();
        }

        /// <summary>
        /// Retrieve password from username | Credential is stored in cache
        /// </summary>
        /// <param name="e02f01"> username </param>
        /// <returns> password </returns>
        [HttpGet]
        [Route("api/redis/get/{e02f01}")]
        public HttpResponseMessage GetCache(string e02f01)
        {
            var cachedValue = _objBlRedis.RetrieveFromCache(e02f01);

            if (cachedValue != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, cachedValue);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, $"Credential with username '{e02f01}' not found in cache.");
        }

        /// <summary>
        /// Add credential in cache
        /// </summary>
        /// <param name="e02f01"> username </param>
        /// <param name="e02f02"> password </param>
        /// <returns> added message </returns>
        [HttpPost]
        [Route("api/redis/add")]
        public HttpResponseMessage PostCache([FromBody] Cre02 objCre02)
        {
            _objBlRedis.AddToCache(objCre02.e02f01, objCre02.e02f02);

            return Request.CreateResponse(HttpStatusCode.OK, $"Login with username '{objCre02.e02f01}' added to cache.");
        }

        /// <summary>
        /// Update cache value.
        /// </summary>
        /// <param name="e02f01"> username </param>
        /// <param name="e02f02"> password </param>
        /// <returns> updated message </returns>
        [HttpPut]
        [Route("api/redis/update")]
        public HttpResponseMessage UpdateCache([FromBody] Cre02 objCre02)
        {
            var existingValue = _objBlRedis.RetrieveFromCache(objCre02.e02f01);

            if (existingValue != null)
            {
                _objBlRedis.UpdateCache(objCre02.e02f01, objCre02.e02f02);
                return Request.CreateResponse(HttpStatusCode.OK, $"Login with username '{objCre02.e02f01}' updated in cache.");
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, $"Login with username '{objCre02.e02f01} ' not found in cache.");
        }

        /// <summary>
        /// To delete cache
        /// </summary>
        /// <param name="e02f01"> username </param>
        /// <returns> deleted message </returns>
        [HttpDelete]
        [Route("api/redis/delete/{e02f01}")]
        public HttpResponseMessage DeleteCache(string e02f01)
        {
            var existingValue = _objBlRedis.RetrieveFromCache(e02f01);

            if (existingValue != null)
            {
                _objBlRedis.RemoveFromCache(e02f01);
                return Request.CreateResponse(HttpStatusCode.OK, $"Login with username '{e02f01}' removed from cache.");
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, $"Login with username '{e02f01}' not found in cache.");
        }

    }

}
