using ExpenseTracker.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpenseTracker.Controllers
{
    /// <summary>
    /// Controller which provides facility of Report 
    /// </summary>
    public class CLReportController : ApiController
    {
        /// <summary>
        /// Generates Report for USer
        /// </summary>
        /// <param name="r01f01"> User Id </param>
        /// <returns> Downloads Report File </returns>
        [HttpGet]
        [Route("api/report/{r01f01}")]
        public IHttpActionResult GenerateReport(int r01f01) 
        {
            string filePath = ReportManager.GenerateReport();

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Provide the file for download
                var fileStream = new FileStream(filePath, FileMode.Open);

                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(fileStream)
                };

                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = $"report{r01f01}.txt" // Set the desired file name
                };
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                return ResponseMessage(response);
            }
            else
            {
                return NotFound(); // File not found
            }

        }
    }
}
