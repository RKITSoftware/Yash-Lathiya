using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;
using UrlShortner.Models;

namespace UrlShortner.Controllers
{
    /// <summary>
    /// This controller handles the request related to Url Shortning, Redirection & analytics
    /// </summary>
    public class CLShortenUrlController : ApiController
    {
        // Generates list of URL - Works as a database in this project 
        private static List<Sho01> urlDatabase = new List<Sho01>();

        // Generated short code of url will be of length 6
        private static int shortCodeLength = 6;

        // Out domain
        const string domain = "http://www.urlShortner.com/";  

        /// <summary>
        ///     POST : /api/shorturl
        ///     Accepts long url form body of request & generate short url of it & stores in database
        /// </summary>
        /// <returns> Shorten Url </returns>
        [HttpPost]
        [Route("api/shortUrl")]
        public IHttpActionResult ShortUrl([FromBody] string originalUrl)
        {
            // If original url is wrong
            // Null or Contains white space 
            if(originalUrl == null || originalUrl.Contains(' '))
            {
                return BadRequest("Please Enter Valid Url"); 
            }

            string shortCode = GenerateShortCode(originalUrl);

            var shortenedUrl = new Sho01
            {
                o01f01 = shortCode,
                o01f02 = originalUrl,
                o01f03 = DateTime.Now.AddDays(30),
                o01f04 = 0
            };

            urlDatabase.Add(shortenedUrl);

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
            } while (urlDatabase.Any(url => url.o01f01 == generatedShortCode));
            

            return generatedShortCode;
        }

        /// <summary>
        ///     GET : /api/redirect/{shortCode}
        ///     Redirects to short url & increment click count of that url
        /// </summary>
        /// <param name="shortCode"> Generated Short Code of Url </param>
        /// <returns> Redirects to original Url </returns>
        [HttpGet]
        [Route("api/redirect/{shortCode}")]
        public IHttpActionResult RedirectUrl(string shortCode)
        {
            // Select that Url object
            var shortenedUrl = urlDatabase.FirstOrDefault( url => url.o01f01 == shortCode);

            // If shorten url not found -> returns error " Not found "
            if(shortenedUrl == null)
            {
                return NotFound();
            }
            // Otherwise redirects to the original url by incrementing click count
            else
            {
                //Increment Click count
                shortenedUrl.o01f04 += 1;

                //Redirect to original url
                return Redirect(shortenedUrl.o01f02);
            }
        }

        /// <summary>
        ///     GET : /api/analytics/{shortCode}
        ///     Get analytics of particular url 
        /// </summary>
        /// <param name="shortCode"> Generated Short Code of Url </param>
        /// <returns> Proviedes analytics of that url </returns>
        [HttpGet]
        [Route("api/analytics/{shortCode}")]
        public IHttpActionResult UrlAnalytics(string shortCode)
        {
            // Select that Url object
            var shortenedUrl = urlDatabase.FirstOrDefault(url => url.o01f01 == shortCode);

            // If shorten url not found -> returns error " Not found "
            if (shortenedUrl == null)
            {
                return NotFound();
            }
            // Otherwise shows analytics of that shorten Url
            else
            {
                return Ok(new
                {
                    Message = "Analytics of the Shorten Url",
                    ShortenedUrl = domain + shortenedUrl.o01f01,
                    OriginalUrl = shortenedUrl.o01f02,
                    Expiry = shortenedUrl.o01f03,
                    ClickCount = shortenedUrl.o01f04,
                }) ;
            }
        }
    }
}
