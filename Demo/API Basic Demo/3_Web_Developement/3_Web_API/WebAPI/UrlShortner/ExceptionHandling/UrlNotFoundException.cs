using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace UrlShortner.ExceptionHandling
{
    /// <summary>
    ///     Details of the UrlNotFoundException
    ///     Properties are inherited from the ExceptionFilterAttribute
    /// </summary>
    public class UrlNotFoundException : Exception
    {
        #region Public Methods

        /// <summary>
        /// It gives message that "url is not found", 
        /// It is used when we want not to print shortCode with the error message
        /// </summary>
        public UrlNotFoundException() : base("URL Not Found") 
        {
        
        }

        /// <summary>
        /// It gives message that "url is not found", 
        /// It is used when we want to print shortCode with the error message
        /// </summary>
        /// <param name="shortCode"> ShortCode of the Url </param>
        public UrlNotFoundException(string shortCode) : base($"URL Not Found with the short-code {shortCode}")
        {

        }

        #endregion
    }
}