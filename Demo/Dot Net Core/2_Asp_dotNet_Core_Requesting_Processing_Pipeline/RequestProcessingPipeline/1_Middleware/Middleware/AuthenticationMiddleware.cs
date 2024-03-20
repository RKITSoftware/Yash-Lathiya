using _1_Middleware.BL;
using _1_Middleware.Models;
using System.Text;

namespace _1_Middleware.Middleware
{
    /// <summary>
    /// Middleware
    /// Authenticates username if valid then calls next middleware ( userId Middleware)
    /// </summary>
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Calls constuctor of chain of middleware
        /// </summary>
        /// <param name="next"> next middleware </param>
        public AuthenticationMiddleware(RequestDelegate next)
        {
            Console.WriteLine("** Authentication Middleware Intitialized");
            _next = next;
        }   

        /// <summary>
        /// extracts credential from login request & authenticates it
        /// </summary>
        /// <param name="context"> current context </param>
        /// <returns> calls next middleware if user is authenticated </returns>
        public async Task InvokeAsync(HttpContext context)
        {
            // If Middleware is calling for LoginMethod of CLLogin Controller
            if (context.Request.Path.StartsWithSegments("/api/CLLogin/Login"))
            {
                // Perform middleware logic for specific route7

                // logic for authenticating username
                Console.WriteLine("** Authentication Middleware -> Authentication checked ");

                // So method from controller can read properties too
                context.Request.EnableBuffering();

                string requestBody;
                using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    requestBody = await reader.ReadToEndAsync();

                    // set pointer to initial starting position
                    context.Request.Body.Position = 0;
                }

                // Deserialized request body into LoginDTO 
                var loginRequest = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginDTO>(requestBody);

                // Extracted emailId and password
                string emailID = loginRequest.EmailId;
                string password = loginRequest.Password;

                Console.WriteLine(emailID);
                Console.WriteLine(password);

                // EmailId & Password Authentication
                if(emailID == "string@gmail.com" && password == "string")
                {
                    await _next(context);
                }
                // If user is not authenticated  -> clear cache userId
                else
                {
                    BLRedis objBLRedis = new BLRedis();
                    objBLRedis.RemoveFromCache("userId");
                    await context.Response.WriteAsync("Authentication Failed");
                }
            }
            // From other than login method 
            else
            {
                await _next(context);
            }
        }
    }
}
