using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace StudentAPI.Caching
{
    /// <summary>
    /// Implements Cache, inherits ActionFilterAttribute class 
    /// </summary>
    public class CacheFilter : ActionFilterAttribute
    {
        #region Public Methods

        /// <summary>
        /// Time Duration of the Cache
        /// </summary>
        public int TimeDuration { get; set; }

        /// <summary>
        /// when request is processed, it stores in the cache
        /// </summary>
        /// <param name="context"> Context of the request </param>
        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            // Adds cache context
            context.Response.Headers.CacheControl = new CacheControlHeaderValue
            {
                MaxAge = TimeSpan.FromSeconds(TimeDuration), // Maximum age of the cache
                MustRevalidate = true,                       // Checks cached content is valid - basically checks that server is accesseble or not
                Public = true                                // Defines scope of the cache - Available to all cache types - Public and private
            };
        }

        #endregion
    }
}