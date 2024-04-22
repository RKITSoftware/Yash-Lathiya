using Microsoft.AspNetCore.Mvc.Filters;

namespace _3_Filters.Filter
{
    /// <summary>
    /// Asynchrounous Filter
    /// Prints the message in console at pre-execution and post-execution time 
    /// </summary>
    public class AsyncConsoleFilter : IAsyncActionFilter
    {
        #region Public Methods

        /// <summary>
        /// Prints message in cnsole
        /// </summary>
        /// <param name="context"> current context of filter </param>
        /// <param name="next"> next filter </param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Async Console filter execution started");

            // Call the next filter in the chain
            await next();

            Console.WriteLine("Async Console filter execution completed");
        }

        #endregion
    }

}
