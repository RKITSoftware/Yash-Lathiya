using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _3_Filters.Filter
{
    public class ExceptionFilter : IExceptionFilter
    {
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
    }
}
