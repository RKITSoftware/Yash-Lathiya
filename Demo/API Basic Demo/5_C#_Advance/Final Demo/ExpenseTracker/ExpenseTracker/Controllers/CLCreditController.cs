using ExpenseTracker.BL;
using ExpenseTracker.Models;
using ExpenseTracker.Models.DTO;
using ExpenseTracker.Static;
using System.Net.Http;
using System.Web.Http;

namespace ExpenseTracker.Controllers
{
    /// <summary>
    /// Controller which contains endpoints to deal with credit details 
    /// Its sealed for security > No other class can inherit it
    /// It uses BL from the CreditManager class
    /// All methods are authorized by JWT Token
    /// </summary>
    [Authorize]
    public sealed class CLCreditController : ApiController
    {
        #region Private Members
        
        /// <summary>
        /// Reference of credit manager
        /// </summary>
        private readonly BLCre01 _objBLCre01;

        /// <summary>
        /// Response object of action method
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes object of BLCre01 
        /// </summary>
        public CLCreditController()
        {
            _objBLCre01 = new BLCre01();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To add Credit in Database
        /// </summary>
        /// <param name="objExp01"> Object of Credit </param>
        /// <returns> object of response </returns>
        [HttpPost]
        [Route("api/Credit/Add")]
        public HttpResponseMessage AddCredit(DTOCre01 objDTOCre01)
        {
            // set operation type
            _objBLCre01.operation = Operation.Create;

            // presave
            _objBLCre01.Presave(objDTOCre01);

            // validate 
            _objResponse = _objBLCre01.Validate();

            if (_objResponse.IsError == false)
            {
                // add
                _objBLCre01.Save();
            }

            return _objResponse.ToHttpResponseMessage();
        }

        /// <summary>
        /// To get all credits 
        /// </summary>
        /// <returns> Details of all credits of particular user </returns>
        [HttpGet]
        [Route("api/Credit/Get")]
        public IHttpActionResult GetCredits()
        {
            _objBLCre01.operation = Operation.Retrieve;
            return Ok(_objBLCre01.GetAllCredit());
        }

        /// <summary>
        /// To update credit 
        /// </summary>
        /// <param name="objCre01"> object of Credit which will be stored in place of previous object </param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/credit/Update")]
        public HttpResponseMessage UpdateCredit(DTOCre01 objDTOCre01)
        {
            // set operation type
            _objBLCre01.operation = Operation.Update;

            // presave
            _objBLCre01.Presave(objDTOCre01);

            // validate 
            _objResponse = _objBLCre01.Validate();

            if (_objResponse.IsError == false)
            {
                // update 
                _objBLCre01.Save();
            }

            return _objResponse.ToHttpResponseMessage();
        }

        /// <summary>
        /// To delete Credit 
        /// </summary>
        /// <param name="e01101"> Credit Id </param>
        /// <returns> object of response </returns>
        [HttpDelete]
        [Route("api/Credit/Delete")]
        public HttpResponseMessage DeleteCredit(int e01101)
        {
            // set operation enum 
            _objBLCre01.operation = Operation.Delete;

            // pre delete validate 
            _objResponse = _objBLCre01.IsIdExists(e01101);

            if (_objResponse.IsError == false)
            {
                // delete
                _objResponse = _objBLCre01.DeleteCre01(e01101);
            }

            return _objResponse.ToHttpResponseMessage();

        }

        #endregion
    }
}
 