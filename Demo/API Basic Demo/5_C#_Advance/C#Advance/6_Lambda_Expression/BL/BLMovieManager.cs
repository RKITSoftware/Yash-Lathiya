using _6_Lambda_Expression.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _6_Lambda_Expression.BL
{
    /// <summary>
    /// A class consists of buisness logic of all methods which are entitled in Movie Controller
    /// </summary>
    public class BLMovieManager
    {
        #region Model Data Insertion

        static List<MOV01> lstMov01;

        public BLMovieManager() 
        {
            lstMov01 = new List<MOV01>();
            lstMov01.Add(new MOV01 { v01f01 = "Animal", v01f02 = "Director1", v01f03 = 55005500, v01f04 = "Action", v01f05 = DateTime.Today});
            lstMov01.Add(new MOV01 { v01f01 = "Tiger Zinda Hain", v01f02 = "Director2", v01f03 = 2000000, v01f04 = "Action - Thriller" });
            lstMov01.Add(new MOV01 { v01f01 = "Laila Majnu", v01f02 = "Director3", v01f03 = 1000000, v01f04 = "Romance" });
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Extract movie details from the database by using movieName
        /// Also uses " Lambda Expression " 
        /// </summary>
        /// <param name="movieName"></param>
        /// Returns -> Object of Movie Details
        public MOV01 GetMovieDetails(string movieName)
        {
            MOV01 objMov01 = lstMov01.FirstOrDefault( movie => movie.v01f01 == movieName );

            return objMov01;
        }

        /// <summary>
        /// Find movies which belongs to specific genre
        /// Its using " Lambda Statements " 
        /// </summary>
        /// <param name="genre"></param>
        /// <returns> Array of movies </returns>
        public Array GetbyGenre(string genre)
        {
            List<string> lstMov01Genre = new List<string>();

            lstMov01.ForEach(movie =>
            {
                if (movie.v01f04 == genre)
                {
                    lstMov01Genre.Add(movie.v01f01);
                }
            });

            return lstMov01Genre.ToArray();

        }

        #endregion

    }
}