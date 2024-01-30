﻿using _4_Serialization.BL;
using System.Web.Http;
using System.Xml.Linq;

namespace _4_Serialization.Controllers
{
    /// <summary>
    /// Serialization and Deserialization of the data
    /// </summary>
    public class SerializationController : ApiController
    {
        /// <summary>
        /// Serialization -> JsonObject to JsonString
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/JsonSerialization")]
        public IHttpActionResult JsonSerialization()
        {
            return Ok(SerializationDeserialization.JsonSerialization());
        }

        /// <summary>
        /// Deserialization -> JsonString to JsonObject
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/JsonDeserialization")]
        public IHttpActionResult JsonDeserialization([FromBody] string json)
        {
            return Ok(SerializationDeserialization.JsonDeserialization(json));
        }

        /// <summary>
        /// Serialization -> XmlObject to XmlString
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/XmlSerialization")]
        public IHttpActionResult XmlSerialization([FromBody] XElement xml)
        {
            return Ok(SerializationDeserialization.XmlSerialization(xml));
        }

        /// <summary>
        /// Deserialization -> XmlString to XmlObject
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/XmlDeserialization")]
        public IHttpActionResult XmlDeserialization(string xml)
        {
            return Ok(SerializationDeserialization.XmlDeserialization(xml));
        }

    }
} 
