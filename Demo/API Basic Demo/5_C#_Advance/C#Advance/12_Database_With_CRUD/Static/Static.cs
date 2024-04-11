using System;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using _12_Database_With_CRUD.Models;
using System.Text.Json;

namespace _12_Database_With_CRUD.Static
{ 
    public static class Static
    {
        #region Enum 

        /// <summary>
        /// Opeartions for databse
        /// </summary>
        public enum Operation : byte
        {
            Create,
            Update,
            Delete,
        }

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
            PropertyInfo[] sourceProps = sourceType.GetProperties()
                                                   .Where(prop => prop.IsDefined(typeof(JsonPropertyNameAttribute), false))
                                                   .ToArray();

            // Iterate through source properties
            foreach (PropertyInfo prop in sourceProps)
            {
                // Get the JSON property name from the attribute
                JsonPropertyNameAttribute attribute = (JsonPropertyNameAttribute)Attribute.GetCustomAttribute(prop, typeof(JsonPropertyNameAttribute));
                string targetPropName = attribute.Name;

                // Find corresponding property in target model
                PropertyInfo targetPropertyInfo = targetType.GetProperty(targetPropName);

                // Set the value of the target property from the source property
                targetPropertyInfo.SetValue(targetModel, prop.GetValue(sourceModel));
            }

            return targetModel;
        }

        /// <summary>
        /// Converts Response to HttpResponse
        /// </summary>
        /// <param name="response"> </param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> ToHttpResponseMessageAsync(this Response response)
        {
            var responseContent = new { response.message, response.data };
            var json = JsonSerializer.Serialize(responseContent);

            var httpResponseMessage = new HttpResponseMessage
            {
                StatusCode = (HttpStatusCode)response.statusCode,
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };

            return await Task.FromResult(httpResponseMessage);
        }

        #endregion
    }
}