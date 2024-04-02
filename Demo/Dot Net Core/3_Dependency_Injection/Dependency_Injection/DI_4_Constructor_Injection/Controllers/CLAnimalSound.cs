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
        // dependency over IAnimalSoundService interface
        private IAnimalSoundService _animalSoundService;

        /// <summary>
        /// constructor injection
        /// </summary>
        /// <param name="animalSoundService"> interface of AnimalSoundService</param>
        public CLAnimalSound(IAnimalSoundService animalSoundService)
        {
            _animalSoundService = animalSoundService;
        }

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
    }
}
