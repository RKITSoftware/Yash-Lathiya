using DI_2_Understanding_Lifetime.Services;

namespace DI_2_Understanding_Lifetime.Middleware
{
    /// <summary>
    /// Middleware which using IDateTime interface and adding that to request pipeline
    /// </summary>
    public class DateCustomMiddleware
    {
        #region Private Members

        private readonly RequestDelegate _next;
        private readonly IDateTime _dateTime;

        #endregion

        #region Public Members

        /// <summary>
        /// creating instance of request delegate & interface
        /// </summary>
        /// <param name="next"></param>
        /// <param name="dateTime"></param>
        public DateCustomMiddleware(RequestDelegate next, IDateTime dateTime)
        {
            _next = next;
            _dateTime = dateTime;
        }

        /// <summary>
        /// Implementation of Async Filter
        /// </summary>
        /// <param name="context"> http context </param>
        /// <returns> next middleware </returns>
        public async Task InvokeAsync(HttpContext context)
        {
            //await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(false);
            await Task.Delay(TimeSpan.FromSeconds(10));

            string date = _dateTime.GetDate();

            Console.WriteLine("** From Middleware : " + date);

            context.Items.Add("DATE", date);

            await _next(context);

        }

        #endregion
    }
}
