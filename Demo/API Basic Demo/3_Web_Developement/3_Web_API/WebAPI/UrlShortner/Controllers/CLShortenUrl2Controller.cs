using UrlShortner.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using System.Web.Services.Description;
using UrlShortner.Authentication;
using UrlShortner.Models;
using UrlShortner.Caching;
using UrlShortner.BL;

namespace UrlShortner.Controllers
{
    /// <summary>
    /// This controller handles the request related to Url Shortning, Redirection & analytics
    /// </summary>
    [RoutePrefix("api/v2")]
    public class CLShortenUrl2Controller : ApiController
    {
        #region Private Fields

        // Our domain
        private const string domain = "http://localhost:50704/api/v2/redirect/";

        #endregion

        #region Public Methods

        /// <summary>
        ///     POST : /api/v2/shorturl
        ///     Accepts long url form body of request & generate short url of it & stores in database
        ///     Role based authorization for -> user
        ///     Also validates the userId (User has to use userID to access analytics of own url) 
        /// </summary>
        /// <returns> Shorten Url </returns>
        [HttpPost]
        [Route("shortUrl/{userId}")]
        [UserAuthenticationAttribute]
        [UserAuthorizationAttribute(Roles = "user")]
        public IHttpActionResult ShortUrl([FromBody] string originalUrl, int userId)
        {
            Sho02 objSho02 = BLShortenUrl2.ShortUrl(originalUrl, userId);

            return Ok(new
            {
                Message = "Shorten Url is created Successfully",
                shortenedUrl = domain + objSho02.o02f01
            });
        }

        /// <summary>
        ///     GET : /api/v2/redirect/{shortCode}
        ///     Redirects to short url & increment click count of that url
        ///     Anyone can access it -> No Authentication
        /// </summary>
        /// <param name="shortCode"> Generated Short Code of Url </param>
        /// <returns> Redirects to original Url </returns>
        [HttpGet]
        [Route("redirect/{shortCode}")]
        public IHttpActionResult RedirectUrl(string shortCode)
        {
            string originalUrl = BLShortenUrl2.RedirectUrl(shortCode);
            if (originalUrl == $"URL Not Found with the short-code {shortCode}" || originalUrl == "Url is expired")
            {
                return BadRequest(originalUrl);
            }

            return Redirect(originalUrl);
        }

        /// <summary>
        ///     GET : /api/v2/analytics/{shortCode}
        ///     Get analytics of particular url 
        ///     Role based authorization for -> user
        ///     Also add cache upto max age 10 second
        /// </summary>
        /// <param name="shortCode"> Generated Short Code of Url </param>
        /// <returns> Proviedes analytics of that url </returns>
        [HttpGet]
        [Route("analytics/{shortCode}")]
        [UserAuthenticationAttribute]
        [UserAuthorizationAttribute(Roles = "user")]
        [CacheFilter(TimeDuration = 10)]
        public IHttpActionResult UrlAnalytics(string shortCode, [FromBody] int userId)
        {
            return Ok(BLShortenUrl2.UrlAnalytics(shortCode));
        }

        /// <summary>
        ///     GET : /api/v2/analytics
        ///     Get analytics of all url
        ///     Role based authorization for -> superadmin
        /// </summary>
        /// <returns> Proviedes analytics of all url within database </returns>
        [HttpGet]
        [Route("analytics")]
        [UserAuthenticationAttribute]
        [UserAuthorizationAttribute(Roles = "superadmin")]
        [CacheFilter(TimeDuration = 10)]
        public IHttpActionResult UrlAnalytics()
        {
            return Ok(BLShortenUrl2.lstSho02);
        }

        /// <summary>
        ///     DELETE : /api/v2/deleteUrl/{shortCode}
        ///     This method deletes the shorten url.
        ///     Role based authorization for -> admin 
        /// </summary>
        /// <param name="shortCode"> Short Code </param>
        /// <returns> Ok Response </returns>
        [HttpDelete]
        [Route("deleteurl/{shortCode}")]
        [UserAuthenticationAttribute]
        [UserAuthorizationAttribute(Roles = "admin")]
        public IHttpActionResult DeleteShortenUrl(string shortCode)
        {
            if (BLShortenUrl2.DeleteUrl(shortCode))
            {
                return Ok($"Url with shortCode {shortCode} deleted successfully");
            }
            return BadRequest("Short Code not found");
        }

        #endregion
    }
}
