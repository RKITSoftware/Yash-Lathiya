using _6_Lambda_Expression.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _6_Lambda_Expression.Controllers
{
    /// <summary>
    /// Controller which demonstrates use of Lambda Expression
    /// </summary>
    public class CLMovieController : ApiController
    {
        /// <summary>
        /// Get Movie Details
        /// </summary>
        /// <param name="movieName"></param>
        /// <returns> Object of MOV01 class consisting movie details </returns>
        [HttpGet]
        [Route("api/Movie/Get/{movieName}")]
        public IHttpActionResult GetMovie(string movieName)
        {
            MovieManager movieManager = new MovieManager();
            return Ok(movieManager.GetMovieDetails(movieName));
        }

        /// <summary>
        /// Get list of movie belongs to specific genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns> Array of movies </returns>
        [HttpGet]
        [Route("api/Movie/GetByGenre")]
        public IHttpActionResult GetMovieByGenre(string genre)
        {
            MovieManager movieManager = new MovieManager();
            return Ok(movieManager.GetbyGenre(genre));
        }
    }
}
