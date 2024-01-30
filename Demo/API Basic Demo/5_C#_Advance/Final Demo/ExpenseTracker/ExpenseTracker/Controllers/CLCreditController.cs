using ExpenseTracker.BL;
using ExpenseTracker.Models;
using System.Web.Http;

namespace ExpenseTracker.Controllers
{
    /// <summary>
    /// Controller which contains endpoints to deal with credit details 
    /// Its sealed for security > No other class can inherit it
    /// It uses BL from the CreditManager class
    /// </summary>
    public sealed class CLCreditController : ApiController
    {
        #region Public Methods

        /// <summary>
        /// To add Credit in Database
        /// </summary>
        /// <param name="objExp01"> Object of Credit </param>
        /// <returns> "Credit Added Message "</returns>
        [HttpPost]
        [Route("api/Credit/Add")]
        public IHttpActionResult AddCredit(Cre01 objCre01)
        {
            CreditManager.AddCredit(objCre01);
            return Ok("Added Credit");
        }

        /// <summary>
        /// To get all credits 
        /// </summary>
        /// <returns> Details of all credits of particular user </returns>
        [HttpGet]
        [Route("api/Credit/Get/{e01f02}")]
        public IHttpActionResult GetCredits(int e01f02)
        {
            return Ok(CreditManager.GetAllCredit(e01f02));
        }

        /// <summary>
        /// To update credit 
        /// </summary>
        /// <param name="objCre01"> object of Credit which will be stored in place of previous object </param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/credit/Update")]
        public IHttpActionResult UpdateCredit(Cre01 objCre01)
        {
            CreditManager.UpdateCredit(objCre01);
            return Ok("Credit Updated");
        }

        /// <summary>
        /// To delete Credit 
        /// </summary>
        /// <param name="e01f01"> Credit Id </param>
        /// <returns> " Deleted " if its deleted Successfully </returns>
        [HttpDelete]
        [Route("api/Credit/Delete")]
        public IHttpActionResult DeleteCredit(int e01f01)
        {
            CreditManager.DeleteCredit(e01f01);
            return Ok("Credit Deleted");
        }

        #endregion
    }
}
