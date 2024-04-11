using ServiceStack;
using System;
using System.Linq;
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
    public enum Operation : byte
    {
        Create,
        Update
    }

    #endregion

    /// <summary>
    /// consists all methods & variable which are frequently used in this project 
    /// </summary>
    public static class Static
    {
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

        #endregion
    }

}