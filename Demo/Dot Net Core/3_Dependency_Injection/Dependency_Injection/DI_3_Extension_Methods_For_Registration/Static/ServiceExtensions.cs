using DI_3_Extension_Methods_For_Registration.Services;
using System.Runtime.CompilerServices;

namespace DI_3_Extension_Methods_For_Registration.Static
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddMyService(this IServiceCollection services)
        {
            // Register MyService with the dependency injection container
            services.AddSingleton<IStudentService, StudentService>();

            return services; // This allows chaining of registrations
        }
    }
}
