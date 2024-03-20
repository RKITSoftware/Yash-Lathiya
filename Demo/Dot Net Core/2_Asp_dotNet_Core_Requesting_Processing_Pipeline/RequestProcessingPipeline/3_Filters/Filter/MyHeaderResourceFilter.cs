using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace _3_Filters.Filter
{
    public class MyHeaderResourceFilter : Attribute, IResourceFilter
    {
        private readonly string _headerName;

        public MyHeaderResourceFilter(string headerName)
        {
            _headerName = headerName;
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            // Check if the custom header is present in the request
            if (!context.HttpContext.Request.Headers.ContainsKey(_headerName))
            {
                // If the header is not found, return a forbidden response
                context.Result = new StatusCodeResult(403);
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            // No action needed after the resource is executed
        }
    }
}
