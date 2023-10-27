namespace _19ConsoleToWebApplication
{
    #region Middleware 
    public class CustomMiddleware1 : IMiddleware
    {
        /// <summary>
        /// Class implementation for middleware execution
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello from file 1 \n ");

            await next(context);

            await context.Response.WriteAsync("Hello from file 2 \n ");

        }
    }
    #endregion
}
