﻿using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace UrlShortner.Authentication
{
    /// <summary>
    /// Authenticates User by Id & Password
    /// </summary>
    public class UserAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // If request header has no credential for login
            if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed");
            }
            // If request consists credential for login
            else
            {
                try
                {
                    // It comes with request as parameter
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;

                    // authToken = username:password
                    // authToken is base 64 encoded

                    // To convert string from the base64 encoding 
                    string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                    // To extract username and password
                    string[] credential = decodedAuthToken.Split(':');
                    string username = credential[0];
                    string password = credential[1];

                    // If user credential are correct
                    if (UserAuthentication.Login(username, password))
                    {
                        // userDetails is object consisting all information with the user of that specifies username & password
                        var userDetails = UserAuthentication.GetDetails(username, password);

                        // Generic Identity of user is created which claims username & Id
                        var identity = new GenericIdentity(username);
                        identity.AddClaim(new Claim(ClaimTypes.Name, userDetails.UserName));
                        identity.AddClaim(new Claim("Id", Convert.ToString(userDetails.Id)));

                        // Here principal term represents the user, identity of the user is binded to principal with their roles
                        IPrincipal principal = new GenericPrincipal(identity, userDetails.Role.Split(','));

                        // Assosiates the current thread to authenticated user ( principal )
                        Thread.CurrentPrincipal = principal;
                        if (HttpContext.Current != null)
                        {
                            HttpContext.Current.User = principal;
                        }
                        else
                        {
                            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Authorization Denied"); // Status Code 401
                        }
                    }
                    // If user creadential are incorrect
                    else
                    {
                        // Returns unauthenticated user - " Login Failed " 
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Incorrect Credential"); // Status Code 401
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
    }
}