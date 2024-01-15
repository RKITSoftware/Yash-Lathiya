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
    public class Sho01
    {
        #region Public Variables
        /// <summary>
        /// Short code of Url
        /// </summary>
        public string o01f01 { get; set; }

        /// <summary>
        /// Original Url
        /// </summary>
        public string o01f02 { get; set; }

        /// <summary>
        /// Expiration of Short URL
        /// </summary>
        public DateTime o01f03 { get; set; }

        /// <summary>
        /// ClickCount -> How many times it is clicked
        /// </summary>
        public int o01f04 { get; set; }

        #endregion
    }
}