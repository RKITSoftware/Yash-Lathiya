using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _3_Filters.Filter
{
    /// <summary>
    /// Exception filter with customized message
    /// </summary>
    public class ExceptionFilter : IExceptionFilter
    {
        #region Public Methods

        /// <summary>
        /// When execption occur, it will throw an exeption according to here customized
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            // Create a custom error response
            var errorResponse = new
            {
                StatusCode = 500,
                Message = "This is custom message from ExceptionFilter"
            };

            // Set the result of the context to a JSON response with the custom error message
            context.Result = new JsonResult(errorResponse)
            {
                StatusCode = 500 // Set the status code of the response
            };

            // Mark the exception as handled
            context.ExceptionHandled = true;
        }

        #endregion
    }
}
