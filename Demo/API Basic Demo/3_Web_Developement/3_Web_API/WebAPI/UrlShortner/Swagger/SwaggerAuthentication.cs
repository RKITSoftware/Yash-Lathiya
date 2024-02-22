using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace UrlShortner.Swagger
{
    public class SwaggerAuthentication : IOperationFilter
    {
        #region Public Methods
   
        /// <summary>
        /// Applies authorization settings to an API operation based on filters and attributes.
        /// Checks if the operation requires authorization and is not marked as allowing anonymous access.
        /// If authorization is required, adds a "Authorization" header parameter for basic authentication.
        /// </summary>
        /// <param name="operation">The API operation to which authorization settings are applied.</param>
        /// <param name="schemaRegistry">The schema registry used in the operation.</param>
        /// <param name="apiDescription">Description of the API, including action and filters.</param>

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline();
            var isAuthorized = filterPipeline
                .Select(filterInfo => filterInfo.Instance)
                .Any(filter => filter is AuthorizeAttribute);

            var allowAnonymous = apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();

            if (isAuthorized && !allowAnonymous)
            {
                if (operation.parameters == null)
                {
                    operation.parameters = new List<Parameter>();
                }

                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    type = "string",
                    required = true,
                    description = "Basic Authentication [username:password]"
                });
            }
        }

        #endregion
    }
}