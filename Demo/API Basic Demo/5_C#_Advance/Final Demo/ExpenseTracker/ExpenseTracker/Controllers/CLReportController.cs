using ExpenseTracker.BL;
using System;
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
    /// All methods are authorized from jwt token
    /// </summary>
    [Authorize]
    public sealed class CLReportController : ApiController
    {
        #region Private Members

        /// <summary>
        /// Consists BL logic of Report Manager
        /// </summary>
        private readonly BLRep02 _objBLRep02;

        #endregion

        #region Constructor 

        /// <summary>
        /// create instance of Report controller
        /// </summary>
        public CLReportController()
        {
            _objBLRep02 = new BLRep02();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates Report for User
        /// </summary>
        /// <returns> Downloads Report File </returns>
        [HttpGet]
        [Route("api/report")]
        public IHttpActionResult GenerateReport() 
        {
            string filePath = _objBLRep02.GenerateReport();

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
                    FileName = $"expense_report_{Common.GetUserIdFromClaims()}_{DateTime.Now}.txt" // Set the desired file name
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
