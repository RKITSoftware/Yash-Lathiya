
using ExpenseTracker.Models;
using ServiceStack;
using ServiceStack.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Web;

namespace ExpenseTracker.Static
{

    #region Enum

    /// <summary>
    /// Opeartions for databse
    /// </summary>
    public enum Operation 
    {
        Create,
        Retrieve,
        Update,
        Delete
    }

    #endregion

    /// <summary>
    /// consists all methods & variable which are frequently used in this project 
    /// </summary>
    public static class Static
    {
        #region Public Members

        /// <summary>
        /// Instance of DbFactory ( ORM )
        /// </summary>
        public static IDbConnectionFactory OrmContext { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get userid from jwt token claim
        /// </summary>
        /// <returns> userid (r01f01)</returns>
        /// <exception cref="InvalidOperationException"> If issue related to find claim </exception>
        public static int GetUserIdFromClaims()
        {
            var claimsIdentity = HttpContext.Current.User.Identity as ClaimsIdentity;
            var userIdClaim = claimsIdentity?.Claims.FirstOrDefault(c => c.Type == "r01f01");

            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int r01f01))
            {
                return r01f01;
            }

            // Handle the case when the user ID is not found in claims or cannot be parsed
            throw new InvalidOperationException("User ID not found in claims or invalid.");
        }

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

        /// <summary>
        /// Set Response message 
        /// </summary>
        /// <param name="response"> response object</param>
        /// <param name="isErrorFlag"> error flag </param>
        /// <param name="statusCode"> status code </param>
        /// <param name="message"> message </param>
        /// <param name="dt"> data </param>
        public static void SetResponse(this Response response, bool isErrorFlag, HttpStatusCode statusCode, string message, DataTable dt)
        {
            response.IsError = isErrorFlag;
            response.StatusCode = statusCode;
            response.Message = message;
            response.Data = dt;
        }

        /// <summary>
        /// Set Response message which does not consist error 
        /// </summary>
        /// <param name="response"> response object</param>
        /// <param name="statusCode"> status code </param>
        /// <param name="message"> message </param>
        /// <param name="dt"> data </param>
        public static void SetResponse(this Response response, HttpStatusCode statusCode, string message, DataTable dt)
        {
            response.StatusCode = statusCode;
            response.Message = message;
            response.Data = dt;
        }

        /// <summary>
        /// Set response message with default status code
        /// </summary>
        /// <param name="response"> response object </param>
        /// <param name="message"> message </param>
        /// <param name="dt"> data </param>
        public static void SetResponse(this Response response,string message, DataTable dt)
        {
            response.Message = message;
            response.Data = dt;
        }

        /// <summary>
        /// Converts List to DataTable
        /// </summary>
        /// <typeparam name="T"> models</typeparam>
        /// <param name="list"> list </param>
        /// <returns> data table </returns>
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            DataTable dataTable = new DataTable();

            if (list != null && list.Count > 0)
            {
                // Get all public properties of T
                var properties = typeof(T).GetProperties();

                // Create columns in DataTable for each property
                foreach (var prop in properties)
                {
                    dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }

                // Populate DataTable with data from the list
                foreach (var item in list)
                {
                    DataRow row = dataTable.NewRow();
                    foreach (var prop in properties)
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }
        #endregion
    }

}