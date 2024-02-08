using System;
using System.Web;
using System.Web.Caching;

namespace Caching.BL
{
    /// <summary>
    /// Implements CRUD operation over Cache 
    /// </summary>
    public class BLCaching
    {
        #region Public Methods
 
        /// <summary>
        /// Add item to cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheDurationInMinutes"></param>
        internal void AddToCache(string key, object value, int cacheDurationInMinutes)
        {
            // here 3rd argument represents dependencies 
            // null means no dependecies which leadss to change cache data
            // If any dependency is given then cache also changes as per dependency changes
            HttpContext.Current.Cache.Insert(key, value, null, DateTime.Now.AddMinutes(cacheDurationInMinutes), Cache.NoSlidingExpiration);
        }


        /// <summary>
        /// Remove item from cache by using key
        /// </summary>
        /// <param name="key"></param>
        internal void RemoveFromCache(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }

        /// <summary>
        /// Update item in cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newValue"></param>
        /// <param name="cacheDurationInMinutes"> New duration of cache </param>
        internal void UpdateCache(string key, object newValue, int cacheDurationInMinutes)
        {
            RemoveFromCache(key); // Remove existing item
            AddToCache(key, newValue, cacheDurationInMinutes); // Add updated item
        }

        /// <summary>
        /// Retrieve item from cache by using key
        /// </summary>
        /// <param name="key"></param>
        /// <returns> Value of cache </returns>
        internal object RetrieveFromCache(string key)
        {
            return HttpContext.Current.Cache.Get(key);
        }

        #endregion

    }
}