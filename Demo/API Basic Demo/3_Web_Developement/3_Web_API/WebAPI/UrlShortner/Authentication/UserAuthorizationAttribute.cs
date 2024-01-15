using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http;

namespace UrlShortner.Authentication
{
    /// <summary>
    /// UserAuthorizationAttribute class inherits the properties of AuthorizeAttribute class,
    /// which provides functionalities that provides responses based on user authorization..
    /// </summary>
    public class UserAuthorizationAttribute : AuthorizeAttribute
    {
        #region Protected Method

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            //User is authorized
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //This method provides authorization to authenticated used .. 
                base.HandleUnauthorizedRequest(actionContext);
            }
            // User is not authorized
            else
            {
                // Constructor accepts argument as status code
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden); // Status Code 403
            }
        }

        #endregion
    }
}