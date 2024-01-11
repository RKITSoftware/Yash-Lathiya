using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace VersoningWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // API Version 1
            config.Routes.MapHttpRoute(
                name: "ApiVersion1",
                routeTemplate: "api/v1/student1",
                defaults : new { controller = "STStudentV1"}
            );

            // API Version 2
            config.Routes.MapHttpRoute(
                name: "ApiVersion2",
                routeTemplate: "api/v1/student2",
                defaults: new { controller = "STStudentV2" }
            );
        }
    }
}
