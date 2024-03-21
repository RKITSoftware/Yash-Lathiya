using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace _3_Filters.Filter
{
    public class AsyncConsoleFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Async Console filter execution started");

            // Call the next filter in the chain
            await next();

            Console.WriteLine("Async Console filter execution completed");
        }
    }

}
