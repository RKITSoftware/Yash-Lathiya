using Microsoft.AspNetCore.Mvc.Filters;

namespace _3_Filters.Filter
{
    /// <summary>
    /// Adds header in response
    /// </summary>
    public class MyResponseHeaderFilter : ActionFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        /// <summary>
        /// to accept parameters for header name and value
        /// </summary>
        /// <param name="name"> header name </param>
        /// <param name="value"> header value </param>
        public MyResponseHeaderFilter(string name, string value)
        {
            _name = name;
            _value = value;
        }

        /// <summary>
        /// Override the OnResultExecuting method to add the header to the response
        /// </summary>
        /// <param name="context"> current context </param>
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Add the header to the response
            context.HttpContext.Response.Headers.Add(_name, _value);
            base.OnResultExecuting(context);
        }
    }
}
