using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace StudentAPI.ExceptionHandling
{
    /// <summary>
    ///     Details of the NotImplementedException
    ///     Properties are inherited from the ExceptionFilterAttribute
    /// </summary>
    public class NotImplementedExceptionFilterAttribute : ExceptionFilterAttribute
    {
        #region Public Methods

        /// <summary>
        /// Configures details of the NotImplementedException 
        /// like StatusCode, ResponseMesage etc . 
        /// </summary>
        /// <param name="context"> Context of the action </param>
        public override void OnException(HttpActionExecutedContext context)
        {
            // Set status code of internal server error - 500
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            string errorMessage = string.Empty;

            // Extracting exception type of the context
            var exceptionType = context.Exception.GetType();

            // If context has an exception of NotImplementedException
            // Customized error message is set
            if (exceptionType == typeof(NotImplementedException))
            {
                errorMessage = "This Functionality is not implemented";
            }

            // Configuring the response of context
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(errorMessage),
                ReasonPhrase = "Filter Exception | NotImplementedException"
            };

            // Providing response to the context
            context.Response = response;

        }

        #endregion
    }
}