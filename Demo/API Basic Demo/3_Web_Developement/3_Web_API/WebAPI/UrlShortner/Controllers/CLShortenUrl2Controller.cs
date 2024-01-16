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

namespace UrlShortner.Controllers
{
    /// <summary>
    /// This controller handles the request related to Url Shortning, Redirection & analytics
    /// </summary>
    [RoutePrefix("api/v2")]
    public class CLShortenUrl2Controller : ApiController
    {
        #region Private Fields

        // Generates list of URL - Works as a database in this project 
        private static List<Sho02> urlDatabase = new List<Sho02>();

        // Generated short code of url will be of length 6
        private static int shortCodeLength = 8;

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
            // If original url is wrong
            // Null or Contains white space 
            if (originalUrl == "" || originalUrl.Contains(' '))
            {
                return BadRequest("Please Enter Valid Url");
            }

            // Generate short code
            string shortCode = GenerateShortCode(originalUrl);

            // Add shorten url details in the urlDatabase.

            var shortenedUrl = new Sho02
            {
                o02f01 = shortCode,
                o02f02 = originalUrl,
                o02f03 = DateTime.Now.AddDays(30),
                o02f04 = 0,
                o02f05 = userId
            };
            urlDatabase.Add(shortenedUrl);

            // Return shortenUrl
            return Ok(new
            {
                Message = "Shorten Url is created Successfully",
                shortenedUrl = domain + shortCode
            });
        }

        /// <summary>
        /// Generates short code for the original url
        /// </summary>
        /// <param name="originalUrl"> Original Url </param>
        /// <returns> Short Code</returns>
        private string GenerateShortCode(string originalUrl)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            string generatedShortCode;

            // If generated short code is found in database, then generate new short code by do-while loop
            do
            {
                // Repeat method repeats process for 6 times
                // in process -> Select random char from chars
                // result is converted into array
                generatedShortCode = new string(Enumerable.Repeat(chars, shortCodeLength)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (urlDatabase.Any(url => url.o02f01 == generatedShortCode));


            return generatedShortCode;
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
            // Select that Url object
            var shortenedUrl = urlDatabase.FirstOrDefault(url => url.o02f01 == shortCode);

            // If shorten url not found -> returns error " Not found "
            if (shortenedUrl == null)
            {
                try
                {
                    throw new UrlNotFoundException(shortCode);
                }
                catch (UrlNotFoundException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            // If url is expired -> returns error " Url is expired "
            else if (DateTime.Now > shortenedUrl.o02f03)
            {
                return BadRequest(" Url is expired");
            }
            // Otherwise redirects to the original url by incrementing click count
            else
            {
                //Increment Click count
                shortenedUrl.o02f04 += 1;

                //Redirect to original url
                return Redirect(shortenedUrl.o02f02);
            }
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
            // Select that Url object
            var shortenedUrl = urlDatabase.FirstOrDefault(url => url.o02f01 == shortCode && url.o02f05 == userId);

            // If shorten url not found -> returns error " Not found "
            if (shortenedUrl == null)
            {
                // Custom exception which prints the message of  - URL Not Found with the short-code {shortCode}
                try
                {
                    throw new UrlNotFoundException(shortCode);
                }
                catch (UrlNotFoundException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            // Otherwise shows analytics of that shorten Url
            else
            {
                return Ok(new
                {
                    Message = "Analytics of the Shorten Url",
                    UserId = shortenedUrl.o02f05,
                    ShortenedUrl = domain + shortenedUrl.o02f01,
                    OriginalUrl = shortenedUrl.o02f02,
                    Expiry = shortenedUrl.o02f03,
                    ClickCount = shortenedUrl.o02f04,
                });
            }
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
            return Ok(urlDatabase);
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
            // Find index of the url
            int index = urlDatabase.FindIndex(url => url.o02f01 == shortCode);

            //If shorten url not exists
            if (index == -1)
            {
                return BadRequest(" Url is invalid ");
            }

            // Delete the shortenUrl from database
            urlDatabase.RemoveAt(index);

            return Ok(new
            {
                Message = $"Shorten url with short code {shortCode} deleted successfully"
            });
        }

        #endregion
    }
}
