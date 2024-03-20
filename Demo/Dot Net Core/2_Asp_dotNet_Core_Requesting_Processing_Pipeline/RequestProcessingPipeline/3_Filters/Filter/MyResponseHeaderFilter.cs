using Microsoft.AspNetCore.Mvc.Filters;

namespace _3_Filters.Filter
{
    public class MyResponseHeaderFilter : ActionFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        // Modify the constructor to accept parameters for header name and value
        public MyResponseHeaderFilter(string name, string value)
        {
            _name = name;
            _value = value;
        }

        // Override the OnResultExecuting method to add the header to the response
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Add the header to the response
            context.HttpContext.Response.Headers.Add(_name, _value);
            base.OnResultExecuting(context);
        }
    }
}
