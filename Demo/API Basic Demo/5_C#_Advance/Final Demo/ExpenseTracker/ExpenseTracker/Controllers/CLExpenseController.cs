using ExpenseTracker.BL;
using ExpenseTracker.Filters;
using ExpenseTracker.Models;
using ExpenseTracker.Models.DTO;
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
        private BLExp01 _objBLExp01;

        /// <summary>
        /// Response of HTTP action method
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates instance of BL Expense Manager
        /// </summary>
        public CLExpenseController()
        {
            _objBLExp01 = new BLExp01();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To add Expense in Database
        /// </summary>
        /// <param name="objExp01"> Object of Expense </param>
        /// <returns> object of response </returns>
        [HttpPost]
        [ValidateModel]
        [Route("api/Expense/Add")]
        public IHttpActionResult AddExpense(DTOExp01 objDTOExp01)
        {
            _objBLExp01.operation = Operation.Create;

            // presave
            _objBLExp01.Presave(objDTOExp01);
            
            // validate 
            _objResponse = _objBLExp01.Validate();


            if (!_objResponse.IsError)
            {
                // add
                _objBLExp01.Save();
            }

            return Ok(_objResponse);
        }

        /// <summary>
        /// To get all expenses 
        /// </summary>
        /// <returns> object of response consisting all expenses </returns>
        [HttpGet]
        [Route("api/Expense/Get")]
        public IHttpActionResult GetExpenses() 
        {
            return Ok(_objBLExp01.GetAllExpense());
        }

        /// <summary>
        /// To update expense 
        /// </summary>
        /// <param name="objDTOExp01"> object of Expense which will be stored in place of previous object </param>
        /// <returns> object of response </returns>
        [HttpPut]
        [ValidateModel]
        [Route("api/Expense/Update")]
        public IHttpActionResult UpdateExpense(DTOExp01 objDTOExp01)
        {
            // set operation type
            _objBLExp01.operation = Operation.Update;

            // presave
            _objBLExp01.Presave(objDTOExp01);

            // validate 
            _objResponse = _objBLExp01.Validate();

            if (!_objResponse.IsError)
            {
                // update 
                _objBLExp01.Save();
            }

            return Ok(_objResponse);

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
            // pre delete validate 
            _objResponse = _objBLExp01.PreDeleteValidate(p01101);

            if (!_objResponse.IsError)
            {
                // delete
                _objResponse = _objBLExp01.DeleteExp01(p01101);
            }

            return Ok(_objResponse);

        }

        #endregion
    }
}
