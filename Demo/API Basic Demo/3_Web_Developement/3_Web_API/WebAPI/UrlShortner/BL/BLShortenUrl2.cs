using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using UrlShortner.ExceptionHandling;
using UrlShortner.Models;

namespace UrlShortner.BL
{
    /// <summary>
    /// Consist buisness logic of v2
    /// </summary>
    public class BLShortenUrl2
    {
        #region Private Fields

        // Generates list of URL - Works as a database in this project 
        public static List<Sho02> lstSho02 = new List<Sho02>();

        // Generated short code of url will be of length 8
        private static int shortCodeLength = 8;

        #endregion

        #region Public Methods

        /// <summary>
        /// Generate short code of Original url
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns> Generated shortCode 
        ///             if OriginalUrl is wrong -> returns "Not Found"
        /// </returns>
        public static Sho02 ShortUrl(string originalUrl, int userId)
        {
            // If original url is wrong
            // Null or Contains white space 
            if (originalUrl == "" || originalUrl.Contains(' '))
            {
                throw new UrlNotFoundException();
            }

            // Generate short code
            string shortCode = GenerateShortCode();

            // Add shorten url details in the lstSho02.

            var objSho02 = new Sho02
            {
                o02f01 = shortCode,
                o02f02 = originalUrl,
                o02f03 = DateTime.Now.AddDays(30),
                o02f04 = 0,
                o02f05 = userId
            };

            lstSho02.Add(objSho02);

            return objSho02;

        }


        /// <summary>
        /// Generates short code for the original url
        /// </summary>
        /// <param name="originalUrl"> Original Url </param>
        /// <returns> Short Code</returns>
        private static string GenerateShortCode()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            string generatedShortCode;

            // If generated short code is found in database, then generate new short code by do-while loop
            do
            {
                // Repeat method repeats process for 8 times
                // in process -> Select random char from chars
                //            -> .Next method creates index within chars 
                // result is converted into array
                generatedShortCode = new string(Enumerable.Repeat(chars, shortCodeLength)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (lstSho02.Any(url => url.o02f01 == generatedShortCode));

            return generatedShortCode;
        }

        /// <summary>
        /// Redirects to original url from shortcode & increment click count 
        /// </summary>
        /// <param name="shortCode"></param>
        /// <returns>
        ///     "Original Url" -> If found short code successfully
        ///     "Url is expired" -> If url is expired
        ///     "URL Not Found with the short-code {shortCode}" -> if incorrect short code is given
        /// </returns>
        public static string RedirectUrl(string shortCode)
        {
            // Select that Url object
            var objSho02 = lstSho02.FirstOrDefault(url => url.o02f01 == shortCode);

            // If shorten url not found -> returns error " Not found "
            if (objSho02 == null)
            {
                try
                {
                    throw new UrlNotFoundException(shortCode);
                }
                catch (UrlNotFoundException ex)
                {
                    return ex.Message;
                }
            }
            // If url is expired -> returns error " Url is expired "
            else if (DateTime.Now > objSho02.o02f03)
            {
                return "Url is expired";
            }
            // Otherwise redirects to the original url by incrementing click count
            else
            {
                //Increment Click count
                objSho02.o02f04 += 1;

                return objSho02.o02f02;
            }
        }

        /// <summary>
        /// Select the object of Sho01 by using shortCode
        /// </summary>
        /// <param name="shortCode"></param>
        /// <returns> Object of Sho01 </returns>
        public static object UrlAnalytics(string shortCode, int userId)
        {
            // Select that Url object
            var objSho02 = lstSho02.FirstOrDefault(url => url.o02f01 == shortCode);

            if (objSho02 == null)
            {
                throw new UrlNotFoundException();
            }

            if(objSho02.o02f05 == userId)
            {
                return new
                {
                    Message = "Analytics of the Shorten Url",
                    UserId = objSho02.o02f05,
                    ShortenedUrl = "http://localhost:50704/api/v2/redirect/" + objSho02.o02f01,
                    OriginalUrl = objSho02.o02f02,
                    Expiry = objSho02.o02f03,
                    ClickCount = objSho02.o02f04,
                };
            }
            else
            {
                return new
                {
                    Message = "You have no access for analytics of enetered url"
                };
            }
            
        }

        /// <summary>
        /// Delete url from the database
        /// </summary>
        /// <param name="shortCode"></param>
        /// <returns></returns>
        public static bool DeleteUrl(string shortCode, [FromBody]int userId)
        {
            // Find index of the url
            int index = lstSho02.FindIndex(url => url.o02f01 == shortCode);

            // If shorten url not exists
            if (index == -1)
            {
                return false;
            }
            if (lstSho02[index].o02f05 != userId)
            {
                return false;
            }

            // Delete the shortenUrl from database
            lstSho02.RemoveAt(index);

            return true;
        }

        #endregion
    }
}