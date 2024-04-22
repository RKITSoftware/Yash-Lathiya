using DI_4_Constructor_Injection.Services;

namespace DI_4_Constructor_Injection
{
    public class Startup
    {
        #region Private Members 

        /// <summary>
        /// configuration interface
        /// </summary>
        private readonly IConfiguration _config;

        #endregion

        #region Public Members 

        /// <summary>
        /// instace is given to configuration 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            // registers every string with this value -- [ not advisable ]
            services.AddScoped<string>(_ => "baa");

            // configure values in CowOptions class via IOptions interface 
            services.Configure<CowOptions>(_config.GetSection("CowSettings"));

            // Implementation of IDogsoundService is scoped in DI container
            services.AddScoped<IDogSoundService, DogSoundService>();

            // Implementation of IAnimalSoundService is scoped in DI container
            services.AddScoped<IAnimalSoundService, AnimalSoundService>();
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

        #endregion

    }
}
