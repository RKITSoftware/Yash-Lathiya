using ExpenseTracker.BL;
using ExpenseTracker.Models;
using System.Net.Http;
using System.Threading.Tasks;
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
        BLCreditManager _objBLCreditManager;

        /// <summary>
        /// Response object of action method
        /// </summary>
        private Response _response;

        #endregion

        #region Public Methods

        /// <summary>
        /// To add Credit in Database
        /// </summary>
        /// <param name="objExp01"> Object of Credit </param>
        /// <returns> "Credit Added Message "</returns>
        [HttpPost]
        [Route("api/Credit/Add")]
        public async Task<HttpResponseMessage> AddCredit(DTOCre01 objDTOCre01)
        {
            //_objEmployeeManager.Presave(objDTOEmp01);

            //_response = _objEmployeeManager.Validate(_response);

            //if (_response.isError == false)
            //{
            //    _response = _objEmployeeManager.Save(Static.Static.Operation.Create, _response);
            //}

            //return await _response.ToHttpResponseMessageAsync();

            _objBLCreditManager = new BLCreditManager(Static.Operation.Create);

            // presave
            _objBLCreditManager.Presave(objDTOCre01);

            // validate 
            bool isValid = _objBLCreditManager.Validate();
            if (!isValid)
            {
                return BadRequest("Requested data is not valid");
            }

            // add
            _objBLCreditManager.Save();

            return Ok("Credit Added");
        }

        /// <summary>
        /// To get all credits 
        /// </summary>
        /// <returns> Details of all credits of particular user </returns>
        [HttpGet]
        [Route("api/Credit/Get")]
        public IHttpActionResult GetCredits()
        {
            _objBLCreditManager = new BLCreditManager(Static.Operation.Retrieve);
            return Ok(_objBLCreditManager.GetAllCredit());
        }

        /// <summary>
        /// To update credit 
        /// </summary>
        /// <param name="objCre01"> object of Credit which will be stored in place of previous object </param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/credit/Update")]
        public IHttpActionResult UpdateCredit(DTOCre01 objDTOCre01)
        {
            _objBLCreditManager = new BLCreditManager(Static.Operation.Update);

            // presave
            _objBLCreditManager.Presave(objDTOCre01);

            // validate
            bool isValid = _objBLCreditManager.Validate();
            if (!isValid)
            {
                return BadRequest("Requested data is not valid");
            }

            // update
            _objBLCreditManager.Save();

            return Ok("Credit Updated");
        }

        /// <summary>
        /// To delete Credit 
        /// </summary>
        /// <param name="e01f01"> Credit Id </param>
        /// <returns> " Deleted " if its deleted Successfully </returns>
        [HttpDelete]
        [Route("api/Credit/Delete")]
        public IHttpActionResult DeleteCredit(DTOCre01 objDTOCre01)
        {
            _objBLCreditManager = new BLCreditManager(Static.Operation.Delete);

            _objBLCreditManager.Presave(objDTOCre01);

            _objBLCreditManager.Save();
            return Ok("Credit Deleted");
        }

        #endregion
    }
}
 