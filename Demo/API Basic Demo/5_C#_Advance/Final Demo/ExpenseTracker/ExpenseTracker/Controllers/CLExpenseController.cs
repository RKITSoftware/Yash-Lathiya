using ExpenseTracker.BL;
using ExpenseTracker.Models;
using System;
using System.Web;
using System.Web.Http;

namespace ExpenseTracker.Controllers
{
    /// <summary>
    /// Controller which contains endpoints to deal with Expense details 
    /// Its sealed for security > No other class can inherit it
    /// It uses BL from ExpenseManager class
    /// All methods are authorized from jwt token
    /// </summary>
    [Authorize]
    public sealed class CLExpenseController : ApiController
    {
        #region Public Methods 

        /// <summary>
        /// To add Expense in Database
        /// </summary>
        /// <param name="objExp01"> Object of Expense </param>
        /// <returns> "Expense Added Message "</returns>
        [HttpPost]
        [Route("api/Expense/Add")]
        public IHttpActionResult AddExpense(Exp01 objExp01) 
        {
            BLExpenseManager objBLExpenseManager = new BLExpenseManager();
            objBLExpenseManager.AddExpense(objExp01);
            return Ok("Added Expense");
        }

        /// <summary>
        /// To get expense detail by Date
        /// </summary>
        /// <param name="p01f04"> Date of Expense </param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Expense/GetByUserIdAndDateOfExpense")]
        public IHttpActionResult GetExpense()
        {
            DateTime p01f04 = Convert.ToDateTime(HttpContext.Current.Request.Form["p01f04"]);

            BLExpenseManager objBLExpenseManager = new BLExpenseManager();
            return Ok(objBLExpenseManager.GetExpense(p01f04));
        }

        /// <summary>
        /// To get all expenses 
        /// </summary>
        /// <returns> Details of all Expense </returns>
        [HttpGet]
        [Route("api/Expense/Get")]
        public IHttpActionResult GetExpenses() 
        {
            BLExpenseManager objBLExpenseManager = new BLExpenseManager();
            return Ok(objBLExpenseManager.GetAllExpense());
        }

        /// <summary>
        /// To update expense 
        /// </summary>
        /// <param name="objExp01"> object of Expense which will be stored in place of previous object </param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Expense/Update")]
        public IHttpActionResult UpdateExpense(Exp01 objExp01) 
        {
            BLExpenseManager objBLExpenseManager = new BLExpenseManager();
            objBLExpenseManager.UpdateExpense(objExp01);
            return Ok("Expense Updated");
        }

        /// <summary>
        /// To delete expense 
        /// </summary>
        /// <param name="p01f01"> Expense Id </param>
        /// <returns> " Deleted " if its deleted Successfully </returns>
        [HttpDelete]
        [Route("api/Expense/Delete")]
        public IHttpActionResult DeleteExpense(int p01f01) 
        {
            BLExpenseManager objBLExpenseManager = new BLExpenseManager();
            objBLExpenseManager.DeleteExpense(p01f01);
            return Ok("Expense Deleted");
        }

        #endregion
    }
}
