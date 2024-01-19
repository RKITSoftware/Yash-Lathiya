//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Web;
//using System.Web.Http;
//using System.Web.Http.Controllers;
//using System.Web.Http.Dispatcher;


//namespace UrlShortner.Versioning
//{
//    /// <summary>
//    /// Manages Versioning by applying method of Custom Header
//    /// </summary>
//    public class VersionControllerSelector : DefaultHttpControllerSelector
//    {
//        // To pass in constructor
//        HttpConfiguration _config;

//        #region Public Methods

//        /// <summary>
//        /// Calling constructor by passing private variable config
//        /// </summary>
//        /// <param name="config"> Object of the HttpConfiguration </param>
//        public VersionControllerSelector(HttpConfiguration config) : base(config)
//        {
//            config = _config;
//        }

//        /// <summary>
//        /// Logic of web api to select which controller on basis of customHeader
//        /// </summary>
//        /// <param name="request"> Request by user </param>
//        /// <returns></returns>
//        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
//        {
//            // Collects all controller within web api
//            var controllers = GetControllerMapping();

//            // Get path of the route data
//            var routeData = request.GetRouteData();

//            // Extract name of controller as a string
//            var controllerName = routeData.Values["controller"].ToString();

//            // Default version as 1
//            string versionNumber = "1";

//            //Custom Header name to be checked
//            string customHeaderVersion = "API-Version";

//            // Select the version number from the custom header
//            if (request.Headers.Contains(customHeaderVersion))
//            {
//                versionNumber = request.Headers.GetValues(customHeaderVersion).FirstOrDefault();
//            }

//            // Select the controller as per the version number
//            if (versionNumber == "1")
//            {
//                controllerName = controllerName + "1";
//            }
//            else
//            {
//                controllerName = controllerName + "2";
//            }


//            HttpControllerDescriptor controllerDescriptor;

//            // TryGetValue method returns true if request controller is correct else it returns the false & set controller descriptor
//            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
//            {
//                return controllerDescriptor;
//            }

//            // If not found then it returns null.
//            return null;
//        }

//        #endregion
//    }
//}