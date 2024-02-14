using System.Web.Http;
using WebActivatorEx;
using UrlShortner;
using Swashbuckle.Application;
using System.Collections.Generic;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace UrlShortner
{
    /// <summary>
    /// Configuration class for Swagger and Swagger UI.
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Registers Swagger and Swagger UI with the provided configuration.
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    // Configure Swagger
                    c.SingleApiVersion("v1", "UrlShortner");
                    c.PrettyPrint();

                    // Enable Basic Authentication using a custom filter
                    c.OperationFilter<BasicAuthFilter>();
                })
                .EnableSwaggerUi(c =>
                {
                    // Configure Swagger UI
                    // ... your existing UI configuration
                });
        }
    }

    /// <summary>
    /// Custom Swagger operation filter to add Basic Authentication support.
    /// </summary>
    public class BasicAuthFilter : IOperationFilter
    {
        /// <summary>
        /// Applies the Basic Authentication filter to Swagger operations.
        /// </summary>
        /// <param name="operation">The Swagger operation being processed.</param>
        /// <param name="schemaRegistry">The Swagger schema registry.</param>
        /// <param name="apiDescription">The API description.</param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            // Add a basic authentication parameter to each operation
            var routeParameters = GetRouteParameters(apiDescription);
            operation.parameters = new List<Parameter>();
            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                type = "string",
                required = true,
                description = "Basic HTTP Authentication. Example: 'Basic base64(username:password)'"
            });

            // Add the security definition for basic authentication
            if (operation.security == null)
            {
                operation.security = new List<IDictionary<string, IEnumerable<string>>>();
            }

            var auth = new Dictionary<string, IEnumerable<string>>
            {
                {"basic", new List<string>()}
            };

            operation.security.Add(auth);
        }

        /// <summary>
        /// Retrieves route parameters from the API description.
        /// </summary>
        /// <param name="apiDescription">The API description.</param>
        /// <returns>A collection of route parameters as Swagger parameters.</returns>
        private IEnumerable<Parameter> GetRouteParameters(ApiDescription apiDescription)
        {
            // Extract parameters from the route template
            var routeParameters = apiDescription.RelativePath.Split('/')
                .Where(segment => segment.StartsWith("{") && segment.EndsWith("}"))
                .Select(segment => new Parameter
                {
                    name = segment.TrimStart('{').TrimEnd('}'),
                    @in = "path",  // Assuming the parameters are from the path
                    type = "string", // Change type accordingly based on your API
                    required = true,
                    description = $"Parameter from the route: {segment}"
                });

            return routeParameters;
        }
    }
}
