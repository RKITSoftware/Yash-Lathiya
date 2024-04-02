using DI_2_Understanding_Lifetime.Middleware;
using DI_2_Understanding_Lifetime.Services;

namespace DI_2_Understanding_Lifetime
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            /// Transient 

            // Instance of service is created every time that their injection into class is required..
            // Will print different time on console as object of services are created more than once.. 
            services.AddTransient<IDateTime, DI_2_Understanding_Lifetime.Services.DateTime>();

            /// Singleton

            // Instane of service is created only once
            // Will print same time on console as object of services are created only once.. 
            //services.AddSingleton<IDateTime, DI_2_Understanding_Lifetime.Services.DateTime>();

            /// Scoped

            // Instane of service is created every time when http request is fired 
            // Will throw an error as constructor injection is used..
            //services.AddScoped<IDateTime, DI_2_Understanding_Lifetime.Services.DateTime>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            // Middleware added 
            app.UseMiddleware<DateCustomMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
