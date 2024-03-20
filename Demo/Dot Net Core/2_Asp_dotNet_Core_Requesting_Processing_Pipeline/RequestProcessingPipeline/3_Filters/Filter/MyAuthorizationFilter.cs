using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace _3_Filters.Filter
{
    /// <summary>
    /// Authorization Filter
    /// </summary>
    public class MyAuthorizationFilter : IAuthorizationFilter
    {
        /// <summary>
        /// checks jwt has authorized claim or not
        /// </summary>
        /// <param name="context"> request context </param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check if user is authenticated
            if (!IsAuthorized(context))
            {
                // If not authenticated, return unauthorized status code
                context.Result = new UnauthorizedResult();
                return;
            }

            // Additional authorization logic can be added here
            // For example, check if the user has certain roles or claims

            // If authorization fails, return forbidden status code
            // Otherwise, do nothing and let the request proceed
        }

        /// <summary>
        /// reads jwt token and check jwt claims
        /// </summary>
        /// <param name="context"></param>
        /// <returns> true -> claim : username = yash 
        ///           false -> otherwise
        /// </returns>
        private static bool IsAuthorized(AuthorizationFilterContext context)
        {
            var jwtToken = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (string.IsNullOrEmpty(jwtToken))
            {
                return false; // No JWT token found
            }

            // token handler class reads jwt token 
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                // Validate and parse the JWT token
                var token = tokenHandler.ReadJwtToken(jwtToken);

                // Check if there's a claim with the name "yash"
                var hasYashClaim = token.Claims.Any(c => c.Type == "username" && c.Value == "yash");

                return hasYashClaim;
            }
            catch (SecurityTokenException)
            {
                // Token validation failed
                return false;
            }
        }
    }
}
