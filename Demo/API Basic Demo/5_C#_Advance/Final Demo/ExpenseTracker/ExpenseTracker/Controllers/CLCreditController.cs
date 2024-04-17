using ExpenseTracker.BL;
using ExpenseTracker.Filters;
using ExpenseTracker.Models;
using ExpenseTracker.Models.DTO;
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
        [ValidateModel]
        [Route("api/Credit/Add")]
        public IHttpActionResult AddCredit(DTOCre01 objDTOCre01)
        {
            // set operation type
            _objBLCre01.operation = Operation.Create;

            // presave
            _objBLCre01.Presave(objDTOCre01);

            // validate 
            _objResponse = _objBLCre01.Validate();

            if (!_objResponse.HasError)
            {
                // add
                _objBLCre01.Save();
            }

            return Ok(_objResponse);
        }

        /// <summary>
        /// To get all credits 
        /// </summary>
        /// <returns> Details of all credits of particular user </returns>
        [HttpGet]
        [Route("api/Credit/Get")]
        public IHttpActionResult GetCredits()
        {
            return Ok(_objBLCre01.GetAllCredit());
        }

        /// <summary>
        /// To update credit 
        /// </summary>
        /// <param name="objCre01"> object of Credit which will be stored in place of previous object </param>
        /// <returns></returns>
        [HttpPut]
        [ValidateModel]
        [Route("api/credit/Update")]
        public IHttpActionResult UpdateCredit(DTOCre01 objDTOCre01)
        {
            // set operation type
            _objBLCre01.operation = Operation.Update;

            // presave
            _objBLCre01.Presave(objDTOCre01);

            // validate 
            _objResponse = _objBLCre01.Validate();

            if (!_objResponse.HasError)
            {
                // update 
                _objBLCre01.Save();
            }

            return Ok(_objResponse);
        }

        /// <summary>
        /// To delete Credit 
        /// </summary>
        /// <param name="e01101"> Credit Id </param>
        /// <returns> object of response </returns>
        [HttpDelete]
        [Route("api/Credit/Delete")]
        public IHttpActionResult DeleteCredit(int e01101)
        {
            // pre delete validate 
            _objResponse = _objBLCre01.PreDeleteValidate(e01101);

            if (!_objResponse.HasError)
            {
                // delete
                _objResponse = _objBLCre01.DeleteCre01(e01101);
            }

            return Ok(_objResponse);
        }

        #endregion
    }
}
 