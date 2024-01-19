using System.Web.Http;
using UrlShortner.Authentication;
using UrlShortner.Models;
using UrlShortner.Caching;
using UrlShortner.BL;

namespace UrlShortner.Controllers
{
    /// <summary>
    /// This controller handles the request related to Url Shortning, Redirection & analytics
    /// </summary>
    [RoutePrefix("api/v1")]
    public class CLShortenUrl1Controller : ApiController
    {
        // Out domain
        private const string domain = "http://localhost:50704/api/v1/redirect/";

        #region Public Methods

        /// <summary>
        ///     POST : /api/v1/shorturl
        ///     Accepts long url form body of request & generate short url of it & stores in database
        ///     Role based authorization for -> user
        /// </summary>
        /// <returns> Shorten Url </returns>
        [HttpPost]
        [Route("shortUrl")]
        [UserAuthenticationAttribute]
        [UserAuthorizationAttribute(Roles = "user")]
        public IHttpActionResult ShortUrl([FromBody] string originalUrl)
        {
            Sho01 objSho01 = BLShortenUrl1.ShortUrl(originalUrl);
            
            return Ok(new
            {
                Message = "Shorten Url is created Successfully",
                shortenedUrl = domain + objSho01.o01f01
            });
        }


        /// <summary>
        ///     GET : /api/v1/redirect/{shortCode}
        ///     Redirects to short url & increment click count of that url
        ///     No authentication -> Public access
        /// </summary>
        /// <param name="shortCode"> Generated Short Code of Url </param>
        /// <returns> Redirects to original Url </returns>
        [HttpGet]
        [Route("redirect/{shortCode}")]
        public IHttpActionResult RedirectUrl(string shortCode)
        {
            string originalUrl = BLShortenUrl1.redirectUrl(shortCode);
            if(originalUrl == $"URL Not Found with the short-code {shortCode}" || originalUrl == "Url is expired")
            {
                return BadRequest(originalUrl);
            }

            return Redirect(originalUrl);
        }

        /// <summary>
        ///     GET : /api/analytics/{shortCode}
        ///     Get analytics of particular url 
        ///     Role based authorization for -> User
        /// </summary>
        /// <param name="shortCode"> Generated Short Code of Url </param>
        /// <returns> Proviedes analytics of that url </returns>
        [HttpGet]
        [Route("analytics/{shortCode}")]
        [UserAuthenticationAttribute]
        [UserAuthorizationAttribute(Roles = "user")]
        [CacheFilter(TimeDuration = 10)]
        public IHttpActionResult UrlAnalytics(string shortCode)
        {
            return Ok(BLShortenUrl1.UrlAnalytics(shortCode));    
        }

        /// <summary>
        /// This method deletes the shorten url.
        /// DELETE : api/v1/deleteUrl/{shortCode}
        /// Role based authorization for -> admin
        /// </summary>
        /// <param name="shortCode"> Short Code </param>
        /// <returns> Ok Response </returns>
        [HttpDelete]
        [Route("deleteUrl/{shortCode}")]
        [UserAuthenticationAttribute]
        [UserAuthorizationAttribute(Roles = "admin")]
        public IHttpActionResult DeleteShortenUrl(string shortCode)
        {
            if (BLShortenUrl1.DeleteUrl(shortCode))
            {
                return Ok($"Url with shortCode {shortCode} deleted successfully");
            }
            return BadRequest("Short Code not found");
        }

        #endregion
    }
}
