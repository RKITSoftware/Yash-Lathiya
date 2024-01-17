using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GenericDictionary.Controllers
{
    public class GenericDictionaryController<TKey, TValue> : ApiController
    {
        static Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        [HttpGet]
        public IHttpActionResult GetDictionary()
        {
            return Ok(dictionary);
        }

       

        [HttpPost]
        public IHttpActionResult AddKeyValuePair([FromBody] KeyValuePair<TKey, TValue> keyValuePair)
        {
            dictionary.Add(keyValuePair.Key, keyValuePair.Value);
            return Ok("Key-Value pair added successfully");
        }

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
