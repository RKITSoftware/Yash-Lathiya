using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using MovieAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        #region Private Variables

        private readonly MovieContext _dbContext;

        #endregion

        #region Public Methods

        /// <summary>
        /// Constructor of Movies Controller Class
        /// </summary>
        /// <param name="dbContext"> Context of Movie </param>
        public MoviesController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// GET : api/Movies
        /// </summary>
        /// <returns> List of Movies which are present in database 
        ///     ActionResult<T> automatically serilizes objects in json type
        ///     Response code is 200
        ///     Unhandled response code is 5xx
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            if(_dbContext.Movies == null)
            {
                return NotFound();
            }
            return await _dbContext.Movies.ToListAsync();
        }

        /// <summary>
        /// GET : api/Movies/2 
        /// </summary>
        /// <param name="id"> Id of Movie</param>
        /// <returns> Details of Movie which consists the id
        ///     ActionResult<T> automatically serilizes objects in json type
        ///     Response code is 200
        ///     Unhandled response code is 5xx
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if(_dbContext.Movies == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Movies.FindAsync(id);

            if(movie == null)
            {
                return NotFound();
            }

            return movie;
        }


        // There is a error in post method

        /// <summary>
        /// Creates a movie record in database
        /// </summary>
        /// <param name="movie"> Movie record which will be added to database </param>
        /// <returns>
        ///     Status code - 201 if successful
        ///     
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            // CreateAtAction method adds Location header to the response, 
            // Location header specifies the URI of the newly created movie
            // CreatedAtAction(string actionName, object routeValues, [ActionResultObjectValue] object value);

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        /// <summary>
        /// PUT : api/movies/4
        /// Put Method updates the movie record by using movie id
        /// Put method requires all entity of object not only changes
        /// </summary>
        /// <param name="id"> Id of movie</param>
        /// <param name="movie"> Updated copy of movie </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> PutMovie(int id, Movie movie)
        {
            if(id != movie.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(movie).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// DELETE : api/movies/2
        /// Deletes the record in database by accessing id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteMovies(int id)
        {
            if(_dbContext.Movies == null)
            {
                return BadRequest();
            }

            var movie = await _dbContext.Movies.FindAsync(id);

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Does Movie Exists in database or not
        /// </summary>
        /// <param name="id"> Id of Movie</param>
        /// <returns> True if Movie exists in database else false</returns>
        private bool MovieExists(int id)
        {
            return (_dbContext.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        #endregion
    }
}
