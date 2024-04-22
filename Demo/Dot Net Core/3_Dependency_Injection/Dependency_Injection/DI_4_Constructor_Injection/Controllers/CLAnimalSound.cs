using DI_4_Constructor_Injection.Services;
using Microsoft.AspNetCore.Mvc;

namespace DI_4_Constructor_Injection.Controllers
{
    /// <summary>
    /// Demonstrates constructor injection 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLAnimalSound : ControllerBase
    {
        #region Private Members

        /// <summary>
        /// dependency over IAnimalSoundService interface
        /// </summary>
        private IAnimalSoundService _animalSoundService;

        #endregion

        #region Constructor 

        /// <summary>
        /// constructor injection
        /// </summary>
        /// <param name="animalSoundService"> interface of AnimalSoundService</param>
        public CLAnimalSound(IAnimalSoundService animalSoundService)
        {
            _animalSoundService = animalSoundService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Extracts content by using different constuctor injection approaches
        /// </summary>
        /// <returns> list of all animal sound </returns>
        [HttpGet]
        [Route("PlayAnimalSound")]
        public IActionResult PlayAnimalSound()
        {
            return Ok(_animalSoundService.PlaySounds());
        }

        #endregion

    }
}
