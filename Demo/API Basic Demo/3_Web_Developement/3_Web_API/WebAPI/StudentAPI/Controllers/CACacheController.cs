using StudentAPI.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentAPI.Controllers
{
    /// <summary>
    /// Shows data by using Cache
    /// If user has added items in cart then that cart items with price in the local storage
    /// </summary>
    public class CACacheController : ApiController
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
        [CacheFilter(TimeDuration = 10)]
        public IHttpActionResult GetCart()
        {
            // Cart consists data of itemname and price
            Dictionary<string, int> cart = new Dictionary<string, int>();

            cart.Add("item1", 12000);
            cart.Add("item2", 14000);
            cart.Add("item3", 16000);
            cart.Add("item4", 18000);
            cart.Add("item5", 22000);
            cart.Add("item6", 24000);

            return Ok(cart);
        }

        #endregion
    }
}
