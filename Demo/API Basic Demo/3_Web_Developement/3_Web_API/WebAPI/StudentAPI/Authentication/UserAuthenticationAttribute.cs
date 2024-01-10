using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters; // HttpStatusCode
using System.Net;
using System.Text; // Encoding Class
using System.Threading;
using System.Security.Principal;
using System.Security.Claims; 

namespace StudentAPI.Authentication
{
    public class UserAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // If request header han no credential for login --> Login failed
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed");
            }
            // If request consists credential for login
            else
            {
                try
                {
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;

                    // authToken = username:password
                    // authToken is base 64 encoded

                    string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                    // To extract username and password
                    string[] credential = decodedAuthToken.Split(':');
                    string username = credential[0];
                    string password = credential[1];

                    if (UserAuthentication.Login(username, password))
                    {
                        // For basic authentication - without roles -> here null denotes no role specified
                        //Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);

                        var userDetails = UserAuthentication.GetDetails(username, password);

                        var identity = new GenericIdentity(username);
                        identity.AddClaim(new Claim(ClaimTypes.Name, userDetails.UserName));
                        identity.AddClaim(new Claim(ClaimTypes.Email, userDetails.Email));
                        identity.AddClaim(new Claim("Id", Convert.ToString(userDetails.Id)));

                        IPrincipal principal = new GenericPrincipal(identity, userDetails.Role.Split(','));

                        Thread.CurrentPrincipal = principal;

                        if(HttpContext.Current != null)
                        {
                            HttpContext.Current.User = principal;
                        }
                        else
                        {
                            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Authorization Denied");
                        }
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed");
                    }

                }
                catch(Exception exception)
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception);
                }
                
            }
        }
    }
}