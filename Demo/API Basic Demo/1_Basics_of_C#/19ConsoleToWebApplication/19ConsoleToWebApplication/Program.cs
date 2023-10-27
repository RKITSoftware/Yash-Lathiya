namespace _19ConsoleToWebApplication
{
    class Program
    {
        #region Methods for building and running web application
        /// <summary>
        /// Build & Run the project
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Logging, Hosting, Enviornment etc.
        /// </summary>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
        
             Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webHost =>
                {
                    webHost.UseStartup<Startup>();
                });

        #endregion
    }
}