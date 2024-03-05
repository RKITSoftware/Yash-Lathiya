using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System;

namespace ExpenseTracker.Security
{
    /// <summary>
    /// Middleware for validating JWT tokens in incoming HTTP requests.
    /// </summary>
    /// <remarks>
    /// This class extends the DelegatingHandler to intercept HTTP requests and perform JWT token validation.
    /// The validated claims are set in the current thread's principal and the HttpContext's user for later use.
    /// </remarks>
    public class JwtTokenValidationHandler : DelegatingHandler
    {
        /// <summary>
        /// Handles the asynchronous processing of HTTP requests to validate JWT tokens.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>The asynchronous task representing the HTTP response message.</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = ExtractTokenFromRequest(request);

                if (!string.IsNullOrEmpty(token))
                {
                    var principal = ValidateToken(token);

                    if (principal != null)
                    {
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can use your logging framework here
                Console.WriteLine($"Token validation error: {ex.Message}");
            }

            return base.SendAsync(request, cancellationToken);
        }

        /// <summary>
        /// Extracts the JWT token from the incoming HTTP request.
        /// </summary>
        /// <param name="request">The HTTP request message.</param>
        /// <returns>The extracted JWT token.</returns>
        private string ExtractTokenFromRequest(HttpRequestMessage request)
        {
            // Extract the token from the Authorization header or other location
            // Customize this based on how your client sends the token
            var authorizationHeader = request.Headers.Authorization;
            //var x = request.Headers.Authorization.Scheme;
            return authorizationHeader?.Parameter;
        }

        /// <summary>
        /// Validates the JWT token and returns the associated claims.
        /// </summary>
        /// <param name="token">The JWT token to validate.</param>
        /// <returns>The claims principal if the token is valid; otherwise, null.</returns>
        private ClaimsPrincipal ValidateToken(string token)
        {
            // Add your JWT validation logic here
            // This could involve checking the signature, expiration, etc.

            // For simplicity, let's just decode the token here
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            if (jsonToken != null)
            {
                var claims = new ClaimsIdentity(jsonToken.Claims, "jwt");
                return new ClaimsPrincipal(claims);
            }

            return null;
        }
    }
}
