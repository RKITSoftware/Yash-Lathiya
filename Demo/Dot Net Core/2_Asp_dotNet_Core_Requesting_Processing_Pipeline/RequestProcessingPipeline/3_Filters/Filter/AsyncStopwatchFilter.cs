using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace _3_Filters.Filter
{
    public class AsyncStopwatchFilter : IAsyncActionFilter
    {
        private readonly Stopwatch _stopwatch;

        public AsyncStopwatchFilter()
        {
            _stopwatch = new Stopwatch();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Pre-action logic (optional)
            Console.WriteLine("Async Stopwatch filter execution started");
            _stopwatch.Start();

            // Call the next delegate to proceed with the controller action
            var result = await next();

            // Post-action logic
            _stopwatch.Stop();
            var executionTime = _stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"** Action execution completed in {executionTime} ms .. ");
            Console.WriteLine("Result : " + result);

            // Reset stopwatch for next filter
            _stopwatch.Reset();

            Console.WriteLine("Async Stopwatch filter executed");
        }
    }
}
