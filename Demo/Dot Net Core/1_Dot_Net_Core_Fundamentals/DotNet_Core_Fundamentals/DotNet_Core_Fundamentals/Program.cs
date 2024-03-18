namespace DotNet_Core_Fundamentals
{
    /// <summary>
    /// Main entry point for the class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method responsible for starting an application
        /// </summary>
        /// <param name="args"> Command line arguments </param>
        public static void Main(string[] args)
        {
            Console.WriteLine(args[0] + "**");
            // Build and run the application.
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates a host builder to configure and build the application.
        /// </summary>
        /// <param name="args"> Command line arguments </param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // configures the web host with startup class
                    webBuilder.UseStartup<Startup>();
                });
    }
}
