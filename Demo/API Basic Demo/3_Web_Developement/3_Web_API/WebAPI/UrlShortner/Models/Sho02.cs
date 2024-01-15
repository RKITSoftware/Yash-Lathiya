using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShortner.Models
{
    /// <summary>
    /// Shortened Url Details
    /// Class to manage all URL details
    /// </summary>
    public class Sho02
    {
        #region Public Variables
        /// <summary>
        /// Short code of Url
        /// </summary>
        public string o02f01 { get; set; }

        /// <summary>
        /// Original Url
        /// </summary>
        public string o02f02 { get; set; }

        /// <summary>
        /// Expiration of Short URL
        /// </summary>
        public DateTime o02f03 { get; set; }

        /// <summary>
        /// ClickCount -> How many times it is clicked
        /// </summary>
        public int o02f04 { get; set; }

        /// <summary>
        /// UserId whom created Shorten Url
        /// </summary>
        public int o02f05 { get; set; }

        #endregion
    }
}