using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace _3_Filters.Filter
{
    /// <summary>
    /// Demonstrates execution of resourse filter
    /// </summary>
    public class MyHeaderResourceFilter : Attribute, IResourceFilter
    {
        private readonly string _headerName;

        /// <summary>
        /// initializes filter name
        /// </summary>
        /// <param name="headerName"> from request </param>
        public MyHeaderResourceFilter(string headerName)
        {
            _headerName = headerName;
        }

        /// <summary>
        /// check that header is present in request or not 
        /// </summary>
        /// <param name="context"> current context of request & filter </param>
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Check if the custom header is present in the request
            if (!context.HttpContext.Request.Headers.ContainsKey(_headerName))
            {
                // If the header is not found, return a forbidden response
                context.Result = new StatusCodeResult(403);
            }
        }

        /// <summary>
        /// After execution of filter -> no need of any further implementation 
        /// </summary>
        /// <param name="context"> curerent context </param>
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // No action needed after the resource is executed
        }
    }
}
