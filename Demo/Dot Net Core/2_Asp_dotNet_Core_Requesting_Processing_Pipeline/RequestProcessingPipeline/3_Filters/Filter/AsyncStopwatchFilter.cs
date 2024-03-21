using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace _3_Filters.Filter
{
    /// <summary>
    /// Demonstrates implementation of asynchrounous filter
    /// </summary>
    public class AsyncStopwatchFilter : IAsyncActionFilter
    {
        private readonly Stopwatch _stopwatch;

        /// <summary>
        /// Initialized stopwatch
        /// </summary>
        public AsyncStopwatchFilter()
        {
            _stopwatch = new Stopwatch();
        }

        /// <summary>
        /// start stopwatch at pre-execution time &
        /// stops it at post-execution time
        /// Also prints that time
        /// </summary>
        /// <param name="context"> current context of filter </param>
        /// <param name="next"> next filter </param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Pre-action logic (optional)
            Console.WriteLine("Async Stopwatch filter execution started");
            _stopwatch.Start();

            // Call the next filter to proceed with the controller action
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
