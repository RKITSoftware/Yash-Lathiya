using _4_Serialization.BL;
using _4_Serialization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace _4_Serialization.Controllers
{
    /// <summary>
    /// Serialization and Deserialization of the data
    /// </summary>
    public class SerializationController : ApiController
    {
        /// <summary>
        /// Serialization -> Object to Json
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ObjectToJson")]
        public IHttpActionResult ObjectToJson()
        {
            return Ok(SerializationDeserialization.ObjectToJosn());
        }

        /// <summary>
        /// Deserialization -> Json to Object
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/JsonToObject")]
        public IHttpActionResult JsonToObject([FromBody] string json)
        {
            return Ok(SerializationDeserialization.JsonToObject(json));
        }

        /// <summary>
        /// Serialization -> Json to Xml
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/JsonToXml")]
        public IHttpActionResult JsonToXMl([FromBody]string json)
        {
            return Ok(SerializationDeserialization.JsonToXml(json));
        }

        /// <summary>
        /// Serialization -> Xml to Json
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/XmlToJson")]
        public IHttpActionResult XmlToJson([FromBody] string xml)
        {
            return Ok(SerializationDeserialization.XmlToJson(xml));
        }

    }
} 
