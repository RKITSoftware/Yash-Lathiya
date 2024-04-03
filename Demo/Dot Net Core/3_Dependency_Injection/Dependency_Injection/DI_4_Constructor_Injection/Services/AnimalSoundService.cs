using Microsoft.Extensions.Options;

namespace DI_4_Constructor_Injection.Services
{
    /// <summary>
    /// Class implements interface of IanimalSoundService
    /// </summary>
    public class AnimalSoundService : IAnimalSoundService
    {
        #region Private Members

        private readonly List<string> lstAnimalSounds;

        #endregion

        #region Public Members 

        /// <summary>
        /// Used different constructor injection approaches
        /// </summary>
        /// <param name="dogSoundService"> From another interface </param>
        /// <param name="configuration"> From configuration interface </param>
        /// <param name="options"> From options interface </param>
        /// <param name="sheepSound"> without any interface </param>
        public AnimalSoundService(IDogSoundService dogSoundService, IConfiguration configuration, IOptions<CowOptions> options, string sheepSound)
        {
            lstAnimalSounds = new List<String>() 
            { 
                dogSoundService.GetSound(),
                configuration["CatSound"],
                options.Value.CowSound,
                sheepSound
            };
        }

        /// <summary>
        /// get list of all animal sound 
        /// </summary>
        /// <returns></returns>
        public List<string> PlaySounds()
        {
            return lstAnimalSounds;
        }

        #endregion

    }
}
