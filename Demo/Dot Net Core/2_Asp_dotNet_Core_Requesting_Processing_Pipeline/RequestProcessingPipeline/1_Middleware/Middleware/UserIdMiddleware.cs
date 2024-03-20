using _1_Middleware.BL;

namespace _1_Middleware.Middleware
{
    /// <summary>
    /// Middleware which finds userId
    /// also stores that userId in cache
    /// </summary>
    public class UserIdMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Calls constuctor of chain of middleware
        /// </summary>
        /// <param name="next"> next middleware </param>
        public UserIdMiddleware(RequestDelegate next)
        {
            Console.WriteLine("** UserId Middleware Intitialized");
            _next = next;
        }

        /// <summary>
        /// Add userId in redis cache
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/api/CLLogin/Login"))
            {
                // Retrive userid number
                string userId = "Miracle12345";

                //store userid in redis cache
                BLRedis objBLRedis = new BLRedis();
                objBLRedis.AddToCache("userId", userId);

                Console.WriteLine("** UserId Middleware -> stored userid in cache");
            }

            //Proceed to next
            await _next(context);

        }
    }
}
