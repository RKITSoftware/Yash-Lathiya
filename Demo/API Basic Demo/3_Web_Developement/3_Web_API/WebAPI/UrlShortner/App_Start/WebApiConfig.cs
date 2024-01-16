using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using UrlShortner.Versioning;

namespace UrlShortner
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //Enable CORS

            //First Parameter   : Allows requests from any origin - host
            //Second Parameter  : Allowed Headers
            //Third Parameter   : Allows all HTTP Methods ( GET, POST, PUT , DELETE, etc.) 

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);



            // Web API routes

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            /// Custom Header Versioning

            // Replace the customController with the default httpControllerselector of the web api

            //config.Services.Replace(typeof(IHttpControllerSelector), new VersionControllerSelector(config));

            // Routing path of the customControllerSelector

            //config.Routes.MapHttpRoute(
            //    name: "DefaultRoute",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


        }
    }
}
