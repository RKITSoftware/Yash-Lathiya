using DI_3_Extension_Methods_For_Registration.Services;
using System.Runtime.CompilerServices;

namespace DI_3_Extension_Methods_For_Registration.Static
{
    /// <summary>
    /// Static class contails all members which are in-frequent use
    /// </summary>
    public static class ServiceExtensions
    {
        #region Public Methods 

        /// <summary>
        /// extension methos which register student service in DI container 
        /// </summary>
        /// <param name="services"> collection of services </param>
        /// <returns> services </returns>
        public static IServiceCollection AddMyService(this IServiceCollection services)
        {
            // Register MyService with the dependency injection container
            services.AddSingleton<IStudentService, StudentService>();

            return services; // This allows chaining of registrations
        }

        #endregion

    }
}
