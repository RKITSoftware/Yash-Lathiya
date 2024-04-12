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
        #region Private Members
        
        /// <summary>
        /// consists BL logic of Expense Manager
        /// </summary>
        BLExp01 _objBLExpenseManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates instance of BL Expense Manager
        /// </summary>
        public CLExpenseController()
        {
            _objBLExpenseManager = new BLExp01();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To add Expense in Database
        /// </summary>
        /// <param name="objExp01"> Object of Expense </param>
        /// <returns> "Expense Added Message "</returns>
        [HttpPost]
        [Route("api/Expense/Add")]
        public IHttpActionResult AddExpense(DTOExp01 objDTOExp01)
        {
            // presave
            _objBLExpenseManager.Presave(objDTOExp01);
            
            // validate 
            bool isValid = _objBLExpenseManager.Validate();
            if (!isValid)
            {
                return BadRequest("Requested data is not valid");
            }

            // add
            _objBLExpenseManager.Save(Static.Operation.Create);
            
            return Ok("Expense Added");
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

            return Ok(_objBLExpenseManager.GetExpense(p01f04));
        }

        /// <summary>
        /// To get all expenses 
        /// </summary>
        /// <returns> Details of all Expense </returns>
        [HttpGet]
        [Route("api/Expense/Get")]
        public IHttpActionResult GetExpenses() 
        {
            return Ok(_objBLExpenseManager.GetAllExpense());
        }

        /// <summary>
        /// To update expense 
        /// </summary>
        /// <param name="objExp01"> object of Expense which will be stored in place of previous object </param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Expense/Update")]
        public IHttpActionResult UpdateExpense(DTOExp01 objDTOExp01)
        {
            // presave
            _objBLExpenseManager.Presave(objDTOExp01);
            
            // validate
            bool isValid = _objBLExpenseManager.Validate();
            if (!isValid)
            {
                return BadRequest("Requested data is not valid");
            }

            // update
            _objBLExpenseManager.Save(Static.Operation.Update);

            return Ok("Expense Updated");
        }

        /// <summary>
        /// To delete expense 
        /// </summary>
        /// <param name="p01f01"> Expense Id </param>
        /// <returns> " Deleted " if its deleted Successfully </returns>
        [HttpDelete]
        [Route("api/Expense/Delete")]
        public IHttpActionResult DeleteExpense(int p01101)
        {
            BLExp01 objBLExpenseManager = new BLExp01();
            objBLExpenseManager.DeleteExpense(p01101);
            return Ok("Expense Deleted");
        }

        #endregion
    }
}
