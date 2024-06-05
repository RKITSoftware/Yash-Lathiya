using StackExchange.Redis;

namespace _1_Middleware.BL
{
    /// <summary>
    /// Deals with Redis Cloud Cache
    /// </summary>
    public class BLRedis
    {
        #region Private Members

        /// <summary>
        /// Redis Connection
        /// </summary>
        private readonly ConnectionMultiplexer _redis;

        /// <summary>
        /// Redis Database
        /// </summary>
        private readonly IDatabase _db;

        #endregion

        #region Constructor

        /// <summary>
        /// Connection Establishment with Redis 
        /// </summary>
        public BLRedis()
        {
            // Initialize the ConnectionMultiplexer in the constructor
            // Cloud Redis
            _redis = ConnectionMultiplexer.Connect("redis-14023.c330.asia-south1-1.gce.redns.redis-cloud.com:14023,password=QD48PqAL6a1C3H5bQgozS3LWyexwVbFr");
            _db = _redis.GetDatabase();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add value to the Redis cache
        /// </summary>
        /// <param name="key">Key for the cache entry</param>
        /// <param name="value">Value to be stored in the cache</param>
        public void AddToCache(string key, string value)
        {
            _db.StringSet(key, value);
        }

        /// <summary>
        /// Retrieve value from the Redis cache
        /// </summary>
        /// <param name="key">Key to retrieve the value</param>
        /// <returns>Value from the cache, or null if not found</returns>
        public string RetrieveFromCache(string key)
        {
            return _db.StringGet(key);
        }

        /// <summary>
        /// Remove value from the Redis cache
        /// </summary>
        /// <param name="key">Key for the cache entry to be removed</param>
        public void RemoveFromCache(string key)
        {
            if(_db.KeyExists(key))
            {
                _db.KeyDelete(key);
            }
        }

        #endregion
    }
}
