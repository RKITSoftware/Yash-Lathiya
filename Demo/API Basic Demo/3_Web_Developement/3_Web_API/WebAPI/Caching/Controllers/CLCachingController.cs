using Caching.BL;
using Caching.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Caching.Controllers
{
    /// <summary>
    /// Provides endpoints where user can store its credential in cache
    /// </summary>
    public class CLCachingController : ApiController
    {
        // Instance of BLCaching
        private readonly BLCaching _blCaching;

        /// <summary>
        /// initialized instance of BLCaching class
        /// </summary>
        public CLCachingController()
        {
            _blCaching = new BLCaching();
        }

        /// <summary>
        /// Retrieve password from username | Credential is stored in cache
        /// </summary>
        /// <param name="e01f01"> username </param>
        /// <returns> password </returns>
        [HttpGet]
        [Route("api/cache/get/{e01f01}")]
        public HttpResponseMessage GetCache(string e01f01)
        {
            var cachedValue = _blCaching.RetrieveFromCache(e01f01);

            if (cachedValue != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, cachedValue);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, $"Credential with username '{e01f01}' not found in cache.");
        }

        /// <summary>
        /// Add credential in cache
        /// </summary>
        /// <param name="e01f01"> username </param>
        /// <param name="e01f02"> password </param>
        /// <param name="e01f03"> duration for which cache is valid </param>
        /// <returns> added message </returns>
        [HttpPost]
        [Route("api/cache/add")]
        public HttpResponseMessage PostCache([FromBody] Cre01 objCre01)
        {
            _blCaching.AddToCache(objCre01.e01f01, objCre01.e01f02, objCre01.e01f03);

            return Request.CreateResponse(HttpStatusCode.OK, $"Login with username '{objCre01.e01f01}' added to cache.");
        }

        /// <summary>
        /// Update cache value.
        /// </summary>
        /// <param name="e01f01"> username </param>
        /// <param name="e01f02"> password </param>
        /// <param name="e01f03"> new duration for which cache is valid </param>
        /// <returns> updated message </returns>
        [HttpPut]
        [Route("api/cache/update")]
        public HttpResponseMessage UpdateCache([FromBody] Cre01 objCre01)
        {
            var existingValue = _blCaching.RetrieveFromCache(objCre01.e01f01);

            if (existingValue != null)
            {
                _blCaching.UpdateCache(objCre01.e01f01, objCre01.e01f02, objCre01.e01f03);
                return Request.CreateResponse(HttpStatusCode.OK, $"Login with username '{objCre01.e01f01}' updated in cache.");
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, $"Login with username '{objCre01.e01f01} ' not found in cache.");
        }

        /// <summary>
        /// To delete cache
        /// </summary>
        /// <param name="e01f01"> username </param>
        /// <returns> deleted message </returns>
        [HttpDelete]
        [Route("api/cache/delete/{e01f01}")]
        public HttpResponseMessage DeleteCache(string e01f01)
        {
            var existingValue = _blCaching.RetrieveFromCache(e01f01);

            if (existingValue != null)
            {
                _blCaching.RemoveFromCache(e01f01);
                return Request.CreateResponse(HttpStatusCode.OK, $"Login with username '{e01f01}' removed from cache.");
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, $"Login with username '{e01f01}' not found in cache.");
        }
    }
}
