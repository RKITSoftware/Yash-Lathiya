using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace VersoningWebAPI.CustomControllSelector
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        // To pass in constructor
        HttpConfiguration _config;

        /// <summary>
        /// Calling constructor by passing private variable config
        /// </summary>
        /// <param name="config"> Object of the HttpConfiguration </param>
        public CustomControllerSelector(HttpConfiguration config) : base(config) 
        {
            config = _config;
        }

        /// <summary>
        /// Logic of web api to select which controller
        /// </summary>
        /// <param name="request"> Request by user </param>
        /// <returns></returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            // Collects all controller within web api
            var controllers = GetControllerMapping();

            // Get path of the route data
            var routeData = request.GetRouteData();

            // Extract name of controller as a string
            var controllerName = routeData.Values["controller"].ToString();

            // Default version as 1
            string versionNumber = "1";

            // fethches the query string from the request
            var versionQueryString = HttpUtility.ParseQueryString(request.RequestUri.Query);

            // Set the version number as per the request
            if (versionQueryString["v"] != null)
            {
                versionNumber = versionQueryString["v"].ToString();
            }

            // Select the controller as per the version number
            if (versionNumber == "1")
            {
                controllerName = controllerName + "V1";
            }
            else
            {
                controllerName = controllerName + "V2";
            }


            HttpControllerDescriptor controllerDescriptor;

            // TryGetValue method returns true if request controller is correct else it returns the false & set controller descriptor
            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }

            // If not found then it returns null.
            return null;
        }
    }
}