using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace StudentAPI.JwtToken
{
    /// <summary>
    /// This class authenticates that jwt token is valid or invalid
    /// </summary>
    public class JwtTokenAuthentication : AuthorizationFilterAttribute
    {
        #region Public Methods 

        /// <summary>
        /// Logic of Authorization
        /// </summary>
        /// <param name="actionContext"> Action Context of Request </param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // If request header han no credential for login --> Login failed
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Plese enter jwt token in header"); // Status Code 401
            }
            // If request consists credential for login
            else
            {
                try
                {
                    // It comes with request as parameter
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;

                    // authToken = header.payload.hash
                    // authToken is base 64 encoded

                    // To extract header, payload & hash from the auth token
                    string[] credential = authToken.Split('.');
                    string encodedHeader = credential[0];
                    string encodedPayload = credential[1];
                    string encodedHash = credential[2];

                    // Secret key of the Jwt Token
                    string secretKey = "123456789012345678901234567890123456789012345678901234567890123456789012";

                    // An Algorithm which decodes Jwt Token
                    HMACSHA256 hmacSHA256 = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));

                    // For hash computing
                    // Hash can be computed from header.payload
                    string forHashParameter = encodedHeader + "." + encodedPayload;

                    // Computed hash in byte[]
                    byte[] computedHash =  hmacSHA256.ComputeHash(Encoding.UTF8.GetBytes(forHashParameter));

                    // Some replacement is necessary in computed hash
                    // '+' -> '-'
                    // '/' -> '_'
                    // '=' -> ''
                    string encodedComputedHash = Convert.ToBase64String(computedHash).Replace('+', '-').Replace('/', '_').Replace('=',' ').Trim();

                    // If provided JwtToken is wrong
                    // Returns that is invalid Jwt Token
                    if(encodedHash != encodedComputedHash )
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid Jwt Token"); // Status Code 401
                    }

                    // Logic for jwt token expiry validation

                    //Extract properties of jwt token by default methods
                    // We can validate token by this properties too, but in this code of section custom logic is written
                    var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(authToken) as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;

                    // If token is expired or null then returns that token is expired
                    if (jsonToken == null || jsonToken.ValidTo < DateTime.UtcNow)
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "JWT Token has expired");
                    }
                }
                // If any exception occurs within the process, It returns  Internal Server Error with the exception
                catch (Exception exception)
                {
                    // Returns Internal servar error with the stack of exception 
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception); // Status Code 500
                }
                
            }
        }

        #endregion

    }
}