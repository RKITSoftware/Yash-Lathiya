using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace StudentAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Enable CORS

            //First Parameter   : Allows requests from any origin - host
            //Second Parameter  : Allowed Headers
            //Third Parameter   : Allows all HTTP Methods ( GET, POST, PUT , DELETE, etc.) 
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Add NotImplemented Filter Exception
            // config.Filters.Add(new StudentAPI.ExceptionHandling.NotImplementedExceptionFilterAttribute());
            // Thiese exceptionFilter is workng witho

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
