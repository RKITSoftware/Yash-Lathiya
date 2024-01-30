using ExpenseTracker.BL;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpenseTracker.Controllers
{
    /// <summary>
    /// Controller which contains endpoints to deal with Report Generation 
    /// Its sealed for security > No other class can inherit it
    /// It uses BL from ReportManager class
    /// </summary>
    public sealed class CLReportController : ApiController
    {
        #region Public Methods 

        /// <summary>
        /// Generates Report for USer
        /// </summary>
        /// <param name="r01f01"> User Id </param>
        /// <returns> Downloads Report File </returns>
        [HttpGet]
        [Route("api/report/{r01f01}")]
        public IHttpActionResult GenerateReport(int r01f01) 
        {
            string filePath = ReportManager.GenerateReport(r01f01);

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
                    // File Name = expense_report_userId.txt
                    FileName = $"expense_report_{r01f01}.txt" // Set the desired file name
                };
                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");

                // In response file is downloaded
                return ResponseMessage(response);
            }
            else
            {
                return NotFound(); // File not found
            }

        }

        #endregion
    }
}
