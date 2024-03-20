
namespace _2_Routing
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseRouting();

            // routing 

            app.UseEndpoints(endpoints =>
            {
                // All methods in controller
                endpoints.MapControllers();

                // Map the Greeting action to the /api/CLRouting endpoint with GET method
                //api/CLRouting/?name=yash
                endpoints.MapGet("/api/CLRouting", async context =>
                {
                    // You can handle the request logic directly here
                    string name = context.Request.Query["name"];
                    await context.Response.WriteAsync("Hello World + " + name);
                });

                // Redirect requests from api/CLRouting/hello to api/CLRouting/greetings
                endpoints.MapGet("/api/CLRouting/hello", context =>
                {
                    string name = context.Request.Query["name"];
                    context.Response.Redirect($"/api/CLRouting/greetings?name={name}");
                    return Task.CompletedTask;
                });

                // Add fallback endpoint to catch all unmatched paths
                endpoints.MapFallback(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("Bro , Entered path does not exist !!!");
                });
            });
            
        }
    }
}
