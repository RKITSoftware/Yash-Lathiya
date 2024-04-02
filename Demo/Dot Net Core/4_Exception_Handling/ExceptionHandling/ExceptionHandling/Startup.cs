using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExceptionHandling
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                // Added developer exception page
                // consists original line of code 
                //app.UseDeveloperExceptionPage();

                // Added ExceptionHandler Page 
                // Content is delivered to web browser
                // It is used in production level, where original lines of code should not be visible to users.
                app.UseExceptionHandler( (options) =>
                {
                    options.Run(async (context) =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            string err = "<h1>This is custom error from Exception Handler</h1>" + 
                                          "<h2>Error Message :" + ex.Error.Message + "</h2>" + 
                                          "<h5>Error Stack" + ex.Error.StackTrace + "</h5>";
                            await context.Response.WriteAsync(err);
                        }
                    });
                });
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
