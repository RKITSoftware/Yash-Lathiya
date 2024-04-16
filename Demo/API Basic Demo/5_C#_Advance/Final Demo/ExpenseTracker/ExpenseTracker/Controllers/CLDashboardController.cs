using ExpenseTracker.BL;
using System.Web.Http;

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
        #region Private Members
        
        /// <summary>
        /// reference of Iwallet interface  
        /// </summary>
        private IWallet _objBLDashboard;

        #endregion

        #region Constructor
        
        /// <summary>
        /// Teke reference of IWallet interface 
        /// </summary>
        public CLDashboardController()
        {
            _objBLDashboard = new BLDashboard();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To check current balance for specific user
        /// </summary>
        /// <returns> Current Balance </returns>
        [HttpGet]
        [Route("api/dashboard/balance")]
        public IHttpActionResult MyCurrentBalance()
        {
            return Ok(_objBLDashboard.CurrentBalance());
        }

        /// <summary>
        /// To get total amount of credit for specific user
        /// </summary>
        /// <returns> Tota credit </returns>
        [HttpGet]
        [Route("api/dashboard/credit")]
        public IHttpActionResult GetToatlCredit()
        {
            return Ok(_objBLDashboard.TotalCredit());
        }

        /// <summary>
        /// To get total amount of expense for specific user 
        /// </summary>
        /// <returns> Total Expense </returns>
        [HttpGet]
        [Route("api/dashboard/expense")]
        public IHttpActionResult GetTotalExpense()
        {
            return Ok(_objBLDashboard.TotalExpense());
        }

        #endregion
    }
}
