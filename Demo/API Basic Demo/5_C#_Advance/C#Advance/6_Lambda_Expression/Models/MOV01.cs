using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _6_Lambda_Expression.Models
{
    /// <summary>
    /// Model of Movie
    /// </summary>
    public class MOV01
    {
        #region Public Properties 

        /// <summary>
        /// Name of Movie
        /// </summary>
        public string v01f01 { get; set; }

        /// <summary>
        /// Director Name
        /// </summary>
        public string v01f02 { get; set; }

        /// <summary>
        /// Box Office Collection of Movie
        /// </summary>
        public long v01f03 { get; set; }

        /// <summary>
        /// Genre of  Movie
        /// </summary>
        public string v01f04 { get; set; }

        /// <summary>
        /// Release Date of Movie
        /// </summary>
        public DateTime? v01f05 { get; set; }

        #endregion
    }
}