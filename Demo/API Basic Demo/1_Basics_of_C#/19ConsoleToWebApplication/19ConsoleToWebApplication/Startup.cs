namespace _19ConsoleToWebApplication
{
    /// <summary>
    /// Contains two significant methods --> ConfigureServices & Configure
    /// </summary>
    public class Startup
    {
        #region Public Methods

        /// <summary>
        /// Used for configuring services that application will use..services means functionalities( database access, logging, authentication )
        /// </summary>
        /// <param name="services">Collection of Service</param>
        public void ConfigureServices(IServiceCollection services)
        {
            //for support of web api
            services.AddControllers();

            services.AddTransient<CustomMiddleware1>();
        }

        /// <summary>
        /// Used to configure the HTTP request pipeline (middleware)
        /// </summary>
        /// <param name="app">used to configure middleware</param>
        /// <param name="env">provides information about the hosting environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Use 1.1 \n");

                await next(); //perform next middleware

                await context.Response.WriteAsync("Hello from Use 1.2 \n");
            });

            app.UseMiddleware<CustomMiddleware1>();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Use 2.1 \n");

                await next(); //perform next middleware

                await context.Response.WriteAsync("Hello from Use 2.2 \n");
            });

            app.Map("/yash", CustomCode);

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Use 3.1 \n");

                await next(); //perform next middleware

                await context.Response.WriteAsync("Hello from Use 3.2 \n");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello From Run \n");
            });

            //Below code has no impact on output because middleware implementation is already performed above..
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello From Run 2");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //Middleware
            }

            app.UseRouting(); // Middleware

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #endregion

        #region Private Methods
        private void CustomCode(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Yash Lathiya \n");
                await next();
            });
        }

        #endregion
    }
}
