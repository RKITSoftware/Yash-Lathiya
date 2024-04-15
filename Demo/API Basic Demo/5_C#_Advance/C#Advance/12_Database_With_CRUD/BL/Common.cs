using _12_Database_With_CRUD.Models;
using ServiceStack.Data;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace _12_Database_With_CRUD.BL
{
    public static class Common
    {
        #region Enum 

        /// <summary>
        /// Opeartions for databse
        /// </summary>
        public enum Operation 
        {
            Create,
            Update
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Instance of DbFactory ( ORM )
        /// </summary>
        public static IDbConnectionFactory OrmContext { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Converts properties of a source model to properties of a target model based on JSON property names.
        /// </summary>
        /// <typeparam name="T">The type of the target model.</typeparam>
        /// <param name="sourceModel">The source model whose properties are to be converted.</param>
        /// <returns>A new instance of the target model with properties populated from the source model.</returns>
        public static T ConvertModel<T>(this object sourceModel)
        {
            // generates blank instance of type T
            T targetModel = Activator.CreateInstance<T>();

            // Type contains className, all properties within class, etc..
            Type sourceType = sourceModel.GetType();
            Type targetType = typeof(T);

            // Get source properties with JSON property name attributes
            PropertyInfo[] sourceProps = sourceType.GetProperties().ToArray();

            // Iterate through source properties
            foreach (PropertyInfo sourceProp in sourceProps)
            {
                // get field name from source model
                string sourcePropName = sourceProp.Name;

                // fetch that field from target model
                PropertyInfo targetProp = targetType.GetProperty(sourcePropName);

                // If target model consists that field then assign value 
                targetProp?.SetValue(targetModel, sourceProp.GetValue(sourceModel, null), null);
            }

            return targetModel;
        }

        /// <summary>
        /// Converts Response to HttpResponse
        /// </summary>
        /// <param name="response"> </param>
        /// <returns></returns>
        public static HttpResponseMessage ToHttpResponseMessage(this Response response)
        {
            var responseContent = new { response.Message, response.Data };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(responseContent);

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = (HttpStatusCode)response.StatusCode,
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };

            return httpResponseMessage;
        }

        #endregion
    }
}