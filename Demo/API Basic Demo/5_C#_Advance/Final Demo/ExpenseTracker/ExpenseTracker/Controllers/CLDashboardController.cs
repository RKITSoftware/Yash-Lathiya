﻿using ExpenseTracker.BL;
using System.Security.Claims;
using System;
using System.Web.Http;
using System.Linq;
using ExpenseTracker.Static;

namespace ExpenseTracker.Controllers
{
    /// <summary>
    /// Controller which contains endpoints to deal with Dashboard details 
    /// Its sealed for security > No other class can inherit it
    /// It uses BL from DashboardManager class
    /// All methods are authorized by JWT Token
    /// </summary>
    [Authorize]
    public class CLDashboardController : ApiController
    {
        #region Public Methods 

        /// <summary>
        /// To check current balance for specific user
        /// </summary>
        /// <returns> Current Balance </returns>
        [HttpGet]
        [Route("api/dashboard/balance")]
        public IHttpActionResult MyCurrentBalance()
        {
            BLDashboardManager dashboard = new BLDashboardManager();
            return Ok(dashboard.CurrentBalance());
        }

        /// <summary>
        /// To get total amount of credit for specific user
        /// </summary>
        /// <returns> Tota credit </returns>
        [HttpGet]
        [Route("api/dashboard/credit")]
        public IHttpActionResult GetToatlCredit()
        {
            BLDashboardManager dashboard = new BLDashboardManager();
            return Ok(dashboard.TotalCredit());
        }

        /// <summary>
        /// To get total amount of expense for specific user 
        /// </summary>
        /// <returns> Total Expense </returns>
        [HttpGet]
        [Route("api/dashboard/expense")]
        public IHttpActionResult GetTotalExpense()
        {
            BLDashboardManager dashboard = new BLDashboardManager();
            return Ok(dashboard.TotalExpense());
        }

        #endregion
    }
}
