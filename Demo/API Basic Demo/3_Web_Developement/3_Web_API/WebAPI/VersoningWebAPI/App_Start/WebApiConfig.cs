﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Microsoft.Web.Http;
using VersoningWebAPI.Custom;
using VersoningWebAPI.CustomControllSelector;

namespace VersoningWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            /// By URL Method 

            // API Version 1

            //config.Routes.MapHttpRoute(
            //    name: "ApiVersion1",
            //    routeTemplate: "api/v1/student1",
            //    defaults: new { controller = "STStudentV1" }
            //);

            // API Version 2

            //config.Routes.MapHttpRoute(
            //    name: "ApiVersion2",
            //    routeTemplate: "api/v1/student2",
            //    defaults: new { controller = "STStudentV2" }
            //);



            /// Query String Parameter

            // Replace the customController with the default httpControllerselector of the web api

            //config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelectorQuerySelector(config));

            // Routing path of the customControllerSelector

            //config.Routes.MapHttpRoute(
            //    name: "DefaultRoute",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);



            /// Custom Header Versioning

            // Replace the customController with the default httpControllerselector of the web api

            //config.Services.Replace(typeof(IHttpControllerSelector), new CustomControlSelectorCustomHeader(config));

            // Routing path of the customControllerSelector

            //config.Routes.MapHttpRoute(
            //    name: "DefaultRoute",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);




            /// Accept Header Versioning

            // Replace the customController with the default httpControllerselector of the web api

            config.Services.Replace(typeof(IHttpControllerSelector), new CustomControllerSelectorAcceptHeader(config));

            // Routing path of the customControllerSelector

            config.Routes.MapHttpRoute(
                name: "DefaultRoute",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
