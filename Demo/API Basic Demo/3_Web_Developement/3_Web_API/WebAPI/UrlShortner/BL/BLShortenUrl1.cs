using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UrlShortner.ExceptionHandling;
using UrlShortner.Models;

namespace UrlShortner.BL
{
    public static class BLShortenUrl1
    {
        #region Private Fields

        // Generates list of URL - Works as a database in this project 
        public static List<Sho01> lstSho01 = new List<Sho01>();

        // Generated short code of url will be of length 6
        private static int shortCodeLength = 6;

        #endregion

        /// <summary>
        /// Generate short code of Original url
        /// </summary>
        /// <param name="originalUrl"></param>
        /// <returns> Generated shortCode 
        ///             if OriginalUrl is wrong -> returns "Not Found"
        /// </returns>
        public static Sho01 ShortUrl(string originalUrl)
        {
            // If original url is wrong
            // Null or Contains white space 
            if (originalUrl == null || originalUrl.Contains(' '))
            {
                throw new UrlNotFoundException();
            }

            // Generate short code
            string shortCode = GenerateShortCode();

            // Add shorten url details in the lstSho02.

            var objSho01 = new Sho01
            {
                o01f01 = shortCode,
                o01f02 = originalUrl,
                o01f03 = DateTime.Now.AddDays(30),
                o01f04 = 0
            };

            lstSho01.Add(objSho01);

            return objSho01;
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
                // Repeat method repeats process for 6 times
                // in process -> Select random char from chars
                // result is converted into array
                generatedShortCode = new string(Enumerable.Repeat(chars, shortCodeLength)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (lstSho01.Any(url => url.o01f01 == generatedShortCode));

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
        public static string redirectUrl(string shortCode)
        {
            // Select that Url object
            var shortenedUrl = lstSho01.FirstOrDefault(url => url.o01f01 == shortCode);

            // If shorten url not found -> returns error " Not found "
            if (shortenedUrl == null)
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
            else if (DateTime.Now > shortenedUrl.o01f03)
            {
                return "Url is expired";
            }
            // Otherwise redirects to the original url by incrementing click count
            else
            {
                //Increment Click count
                shortenedUrl.o01f04 += 1;

                return shortenedUrl.o01f02;
            }
        }

        /// <summary>
        /// Select the object of Sho01 by using shortCode
        /// </summary>
        /// <param name="shortCode"></param>
        /// <returns> Object of Sho01 </returns>
        public static object UrlAnalytics(string shortCode)
        {
            // Select that Url object
            var objSho01 = lstSho01.FirstOrDefault(url => url.o01f01 == shortCode);

            if(objSho01 == null)
            {
                throw new UrlNotFoundException();
            }

            return new {
                Message = "Analytics of the Shorten Url",
                ShortenedUrl = "http://localhost:50704/api/v1/redirect/" + objSho01.o01f01,
                OriginalUrl = objSho01.o01f02,
                Expiry = objSho01.o01f03,
                ClickCount = objSho01.o01f04
            };
        }

        /// <summary>
        /// Delete url from the database
        /// </summary>
        /// <param name="shortCode"></param>
        /// <returns></returns>
        public static bool DeleteUrl(string shortCode)
        {
            // Find index of the url
            int index = lstSho01.FindIndex(url => url.o01f01 == shortCode);

            //If shorten url not exists
            if (index == -1)
            {
                return false;
            }

            // Delete the shortenUrl from database
            lstSho01.RemoveAt(index);

            return true;
        }
    }
}