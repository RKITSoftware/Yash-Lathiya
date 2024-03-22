using Dependency_Injection.Interfaces;
using Dependency_Injection.Services;

namespace Dependency_Injection
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            //services.AddSingleton<IProductService, ProductService>();
            //services.AddTransient<IProductService, ProductService>();
            //services.AddScoped<IProductService, ProductService>();
            services.AddSingleton<IProductService, MySqlProductService>();

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
