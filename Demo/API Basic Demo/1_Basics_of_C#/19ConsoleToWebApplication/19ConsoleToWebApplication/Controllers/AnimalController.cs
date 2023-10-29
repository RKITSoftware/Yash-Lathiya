using _19ConsoleToWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _19ConsoleToWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        #region Public Methods for Routing

        /// <summary>
        /// shows list of animal details ..
        /// </summary>
        /// <returns>Animal Data with OK Status</returns>
        [Route("")]
        public IActionResult GetAnimals()
        {
            var animals = new List<AnimalModel>()
            {
                new AnimalModel(){ Id = 1 , Name = "Dog"},
                new AnimalModel(){ Id = 2 , Name = "Cat"}
            };
            return Ok(animals); //Status code 200
        }

        /// <summary>
        /// shows list of animal details
        /// </summary>
        /// <returns>Animal data with Status code 202</returns>
        [Route("test")]
        public IActionResult GetAnimalsTest()
        {
            var animals = new List<AnimalModel>()
            {
                new AnimalModel(){ Id = 1 , Name = "Dog"},
                new AnimalModel(){ Id = 2 , Name = "Cat"}
            };
            return Accepted(animals); //status code 202
        }

        /// <summary>
        /// Checks constraint in url and shows result according to that
        /// </summary>
        /// <param name="name">AnimalName</param>
        /// <returns>Different status code according to url</returns>
        [Route("{name}")]
        public IActionResult GetAnimalsByName(string name)
        {
            if (name.Contains("XYZ"))
            {
                return NoContent(); //status code 404
            }

            if (!name.Contains("ABC"))
            {
                return BadRequest(); //status code 400
            }

            return Ok();
        }
        #endregion
    }
}
