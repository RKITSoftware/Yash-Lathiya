﻿using System.Data;
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
        public bool HasError { get; set; } = false;

        /// <summary>
        /// Status Code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        /// <summary>
        /// Messege
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Data in response 
        /// </summary>
        public DataTable Data { get; set; }

        #endregion

    }
}