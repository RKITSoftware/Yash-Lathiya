using ExpenseTracker.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExpenseTracker.Controllers
{
    /// <summary>
    /// Controller which contains endpoints to deal with Dashboard details 
    /// Its sealed for security > No other class can inherit it
    /// It uses BL from DashboardManager class
    /// </summary>
    public class CLDashboardController : ApiController
    {
        #region Public Methods 

        /// <summary>
        /// To check current balance for specific user
        /// </summary>
        /// <param name="r01f01"> User Id </param>
        /// <returns> Current Balance </returns>
        [HttpGet]
        [Route("api/dashboard/balance/{r01f01}")]
        public IHttpActionResult MyCurrentBalance(int r01f01)
        {
            DashboardManager dashboard = new DashboardManager();
            return Ok(dashboard.CurrentBalance(r01f01));
        }

        /// <summary>
        /// To get total amount of credit for specific user
        /// </summary>
        /// <param name="r01f01"> User Id </param>
        /// <returns> Tota credit </returns>
        [HttpGet]
        [Route("api/dashboard/credit/{r01f01}")]
        public IHttpActionResult GetToatlCredit(int r01f01)
        {
            DashboardManager dashboard = new DashboardManager();
            return Ok(dashboard.TotalCredit(r01f01));
        }

        /// <summary>
        /// To get total amount of expense for specific user 
        /// </summary>
        /// <param name="r01f01"> User Id </param>
        /// <returns> Total Expense </returns>
        [HttpGet]
        [Route("api/dashboard/expense/{r01f01}")]
        public IHttpActionResult GetTotalExpense(int r01f01)
        {
            DashboardManager dashboard = new DashboardManager();
            return Ok(dashboard.TotalExpense(r01f01));
        }

        #endregion
    }
}
