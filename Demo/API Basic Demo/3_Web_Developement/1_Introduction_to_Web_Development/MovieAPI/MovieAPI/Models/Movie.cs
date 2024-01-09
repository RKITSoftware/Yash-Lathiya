namespace MovieAPI.Models
{
    public class Movie
    {
        #region Public Methods

        /// <summary>
        /// Id of Movie
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nullable Title of Movie
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Nullable Genre of Movie
        /// </summary>
        public string? Genre { get; set; }

        /// <summary>
        /// Release Date of Movie
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        #endregion
    }
}
