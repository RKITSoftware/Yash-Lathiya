using System.Net;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Model of IAction response 
    /// </summary>
    public class Response
    {
        #region Public Members

        /// <summary>
        /// Is there error in response or not
        /// </summary>
        public bool isError { get; set; } = false;

        /// <summary>
        /// Status Code
        /// </summary>
        public HttpStatusCode statusCode { get; set; }

        /// <summary>
        /// Messege
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Data in response 
        /// </summary>
        public object data { get; set; }

        #endregion

    }
}