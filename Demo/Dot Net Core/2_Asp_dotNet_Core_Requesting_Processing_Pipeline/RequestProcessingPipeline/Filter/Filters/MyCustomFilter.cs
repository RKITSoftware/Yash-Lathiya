using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Filter.Filters
{
    public class MyCustomFilter : IActionFilter
    {
        private readonly ILogger<MyCustomFilter> _logger;
        
        public MyCustomFilter(ILogger<MyCustomFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Executing Action...{context}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation($"Executed {context}");
        }
    }
}
