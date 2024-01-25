using System.Collections.Generic;
using System.Web.Http;

namespace GenericDictionary.Controllers
{
    /// <summary>
    /// Generic Controller which is selected on basis of Key & Value 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class GenericDictionaryController<TKey, TValue> : ApiController
    {
        static Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        /// <summary>
        /// Get items in generic Dictionary
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetDictionary()
        {
            return Ok(dictionary);
        }

        /// <summary>
        /// Add item in generic dictionary
        /// </summary>
        /// <param name="keyValuePair"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AddKeyValuePair([FromBody] KeyValuePair<TKey, TValue> keyValuePair)
        {
            dictionary.Add(keyValuePair.Key, keyValuePair.Value);
            return Ok("Key-Value pair added successfully");
        }

        /// <summary>
        /// Update item in generic dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public IHttpActionResult UpdateValue(TKey key, [FromBody] TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
                return Ok("Value updated successfully");
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Delete item from generic key 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public IHttpActionResult DeleteByKey(TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary.Remove(key);
                return Ok("Key-Value pair deleted successfully");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
