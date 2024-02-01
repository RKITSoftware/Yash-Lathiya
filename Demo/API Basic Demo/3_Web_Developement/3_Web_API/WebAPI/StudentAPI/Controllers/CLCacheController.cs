using StudentAPI.BL;
using StudentAPI.Caching;
using System.Web.Http;

namespace StudentAPI.Controllers
{
    /// <summary>
    /// Shows data by using Cache
    /// If user has added items in cart then that cart items with price in the local storage
    /// </summary>
    public class CLCacheController : ApiController
    {
        #region Public Methods

        /// <summary>
        /// GET : /api/cart/
        ///     Implements Cache functionality for the time duration of 100 seconds
        /// </summary>
        /// <returns>
        ///     Cart of the user with the item name and price, that data is stored in cache
        /// </returns>
        [HttpGet]
        [Route("api/cart/")]
        [CacheFilter(TimeDuration = 100)]
        public IHttpActionResult GetCart()
        {
            return Ok(CacheManager.GetProducts());    
        }

        #endregion
    }
}
