using Microsoft.AspNetCore.Mvc.Filters;

namespace _3_Filters.Filter
{
    /// <summary>
    /// Custom Filter which logs the information
    /// </summary>
    public class MyCustomFilter : IActionFilter
    {
        private readonly ILogger<MyCustomFilter> _logger;

        /// <summary>
        /// constructor -- initializes logger
        /// </summary>
        /// <param name="logger"></param>
        public MyCustomFilter(ILogger<MyCustomFilter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// on filter execution
        /// </summary>
        /// <param name="context"> current context </param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // This method is called before the action method is executed
            _logger.LogInformation("Executing action...");
            Console.WriteLine("Action is executing");
            // Your custom logic before the action method executes
        }

        /// <summary>
        /// Afetr filter execution
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // This method is called after the action method is executed
            _logger.LogInformation("Action executed.");
            Console.WriteLine("Action is executed");
            // Your custom logic after the action method executes
        }
    }
}
