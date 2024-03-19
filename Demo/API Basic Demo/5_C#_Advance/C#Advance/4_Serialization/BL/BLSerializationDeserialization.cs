using _4_Serialization.Models;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace _4_Serialization.BL
{
    /// <summary>
    /// Json Serialization
    /// </summary>
    public static class BLSerializationDeserialization
    {
        /// <summary>
        /// Convert object to Json String
        /// </summary>
        /// <returns></returns>
        public static string JsonSerialization()
        {
            // Object of Stu01 class
            Stu01 objStu01 = new Stu01 { u01f01 = 1001, u01f02 = "Yash Lathiya", u01f03 = "Gujarat Technological University" };

            /// Serialization of that object

            // by javascript serializer
            
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //string serializedObject = serializer.Serialize(objStu01);

            // by jsonConvert

            string serializedObject = JsonConvert.SerializeObject(objStu01);

            return serializedObject;
        }

        /// <summary>
        /// Convert json string to object
        /// </summary>
        /// <param name="json"> string of json data</param>
        /// <returns> Object of that json data </returns>
        public static Stu01 JsonDeserialization(string json)
        {
            /// Deserialize JSON to Stu01 object

            // by javascript serializer

            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //Stu01 objStu01 = serializer.Deserialize<Stu01>(json);

            // by jsonConvert

            Stu01 objStu01 = JsonConvert.DeserializeObject<Stu01>(json);

            return objStu01;
        }

        /// <summary>
        /// Xml Serialization
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static string XmlSerialization(XElement xml)
        {
            return JsonConvert.SerializeXNode(xml);
        }

        /// <summary>
        /// Xml Deserialization
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static XElement XmlDeserialization(string xmlString)
        {
            return JsonConvert.DeserializeXNode($"{{\"Root\":{xmlString}}}").Root;
        }

    }
}
