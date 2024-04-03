using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Logging
{
    public class Startup
    {
        public Startup()
        {
            // providing nlog configuration file 
            NLog.LogManager.LoadConfiguration("C:\\Users\\yash.l\\source\\repos\\Yash-Lathiya\\Demo\\Dot Net Core\\5_Logging\\Logging\\Logging\\Nlog\\Nlog.config");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            // Configure Logging 
            services.AddLogging( logging =>
            {
                // clear all providers
                logging.ClearProviders();

                // add console
                logging.AddConsole();

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                // Added developer exception page
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
