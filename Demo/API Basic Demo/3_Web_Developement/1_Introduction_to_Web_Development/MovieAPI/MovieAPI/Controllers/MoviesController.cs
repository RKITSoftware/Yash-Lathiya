using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        #region Private
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

        #endregion


    }
}
