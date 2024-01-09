using Microsoft.EntityFrameworkCore;

namespace MovieAPI.Models
{
    /// <summary>
    /// inherits dbContext wchich is part of the Entity Framework Core
    /// </summary>
    public class MovieContext  : DbContext
    {
        /// <summary>
        /// Base constructer implements when instance of MovieContext is created.
        /// </summary>
        /// <param name="options"></param>
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) 
        { 
        
        }

        public DbSet<Movie> Movies { get; set; } = null;
    }
}
