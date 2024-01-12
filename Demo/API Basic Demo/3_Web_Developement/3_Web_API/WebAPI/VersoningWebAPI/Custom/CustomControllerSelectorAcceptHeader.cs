using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace VersoningWebAPI.Custom
{
    /// <summary>
    /// Manages Versioning by applying method of Accept Header
    /// </summary>
    public class CustomControllerSelectorAcceptHeader : DefaultHttpControllerSelector
    {
        // To pass in constructor
        HttpConfiguration _config;

        #region Public Methods

        /// <summary>
        /// Calling constructor by passing private variable config
        /// </summary>
        /// <param name="config"> Object of the HttpConfiguration </param>
        public CustomControllerSelectorAcceptHeader(HttpConfiguration config) : base(config)
        {
            config = _config;
        }

        /// <summary>
        /// Logic of web api to select which controller on basis of Accept Header
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

            // Get accept header which contains version of web api
            // Count method finds out instaces of name 'version' in header which returns to where clause
            var acceptHeader = request.Headers.Accept
                .Where(req => 
                    req.Parameters
                        .Count(field =>
                            field.Name == "version") > 0);

            // If it contains version in accept header
            if (acceptHeader.Any())
            {
                // Get the first value of version from the accept header parameter
                // First method retrieves the first element in property field specified in header
                versionNumber = acceptHeader.First().Parameters.First(field => field.Name == "version").Value;
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

        #endregion
    }
}