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

        public UrlNotFoundException() : base("URL Not Found") 
        {
        
        }

        public UrlNotFoundException(string shortCode) : base($"URL Not Found with the short-code {shortCode}")
        {

        }

        #endregion
    }
}