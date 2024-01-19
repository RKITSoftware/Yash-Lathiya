using _4_Serialization.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Web.Http;

namespace _4_Serialization.BL
{
    /// <summary>
    /// Json Serialization
    /// </summary>
    public static class SerializationDeserialization
    {
        /// <summary>
        /// Convert object to Json String
        /// </summary>
        /// <returns></returns>
        public static string ObjectToJosn()
        {
            // Object of Stu01 class
            Stu01 objStu01 = new Stu01 { u01f01 = 1001, u01f02 = "Yash Lathiya", u01f03 = "Gujarat Technological University" };

            // Serialization of that object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string serializedObject = serializer.Serialize(objStu01);

            return serializedObject;
        }

        /// <summary>
        /// Convert json string to object
        /// </summary>
        /// <param name="json"> string of json data</param>
        /// <returns> Object of that json data </returns>
        public static Stu01 JsonToObject(string json)
        {
            // Deserialize JSON to Stu01 object
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            Stu01 objStu01 = serializer.Deserialize<Stu01>(json);

            return objStu01;
        }
        /// <summary>
        /// Convert json string to xml string
        /// </summary>
        /// <param name="json"> json data in string format </param>
        /// <returns> Xml srring </returns>
        public static string JsonToXml(string json)
        {
            // Deserialize JSON to Dictionary
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var dictionary = serializer.Deserialize<Dictionary<string, object>>(json);

            // Convert dictionary to xml
            var xmlDocument = new XDocument(new XElement("root", ConvertToXml(dictionary)));

            return xmlDocument.ToString();
        }

        /// <summary>
        /// Logic of converting dictionary to xml component
        /// </summary>
        /// <param name="dictionary"> contains data of object </param>
        /// <returns> Xml Element s</returns>
        public static XElement ConvertToXml(Dictionary<string, object> dictionary)
        {
            // Convert Dictionary to XML elements recursively
            return new XElement("root",
                dictionary.Select(kv =>
                {
                    if (kv.Value is Dictionary<string, object>)
                    {
                        // If the value is a nested dictionary, recursively call ConvertToXml
                        return new XElement(kv.Key, ConvertToXml((Dictionary<string, object>)kv.Value));
                    }
                    else
                    {
                        // If the value is a simple type, convert it to string and create an XElement
                        return new XElement(kv.Key, kv.Value.ToString());
                    }
                }));
        }

        /// <summary>
        /// Convert xml string to json string 
        /// </summary>
        /// <param name="xml"> xml data in string fomat </param>
        /// <returns> xml data in string form </returns>
        public static string XmlToJson(string xml)
        {
            // Trim string so it can be parsed easily
            xml = xml.Trim();

            // To parse xml document
            XDocument xmlDocument = XDocument.Parse(xml);

            string jsonString = JsonConvert.SerializeXNode(xmlDocument);
            JObject json = JObject.Parse(jsonString);

            return json.ToString();
        }
    }
}