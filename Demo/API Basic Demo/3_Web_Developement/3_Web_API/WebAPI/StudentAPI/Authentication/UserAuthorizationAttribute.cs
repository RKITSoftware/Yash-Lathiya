using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace StudentAPI.Authentication
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
                // Prints message that " Authorization has been denied for thi request "
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden); // Status Code 403
            }
        }

        #endregion
    }
}