using ExpenseTracker.BL;
using ExpenseTracker.Models;
using System.Web;
using System.Web.Http;

namespace ExpenseTracker.Controllers
{
    /// <summary>
    /// Controller which contains endpoints to deal with User details 
    /// Its sealed for security > No other class can inherit it
    /// It uses BL from UserManager class
    /// </summary>
    public sealed class CLUserController : ApiController
    {
        #region Public Methods

        /// <summary>
        /// To Register User in database 
        /// </summary>
        /// <param name="objUsr01"> Object of User </param>
        /// <returns> Success Message if Registered Successfully </returns>
        [HttpPost]
        [Route("api/User/Register")]
        public IHttpActionResult RegisterUser([FromBody] Usr01 objUsr01) 
        {
            BLUserManager objBLUserManager = new BLUserManager();
            objBLUserManager.RegisterUser(objUsr01);
            return Ok("User Registered");
        }

        /// <summary>
        /// To Login User with help of username and password 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/User/Login")]
        public IHttpActionResult LoginUser([FromBody] Log01 objLog01) 
        {
            BLUserManager objBLUserManager = new BLUserManager();
            bool isAuthenticated = objBLUserManager.LoginUser(objLog01.g01f01, objLog01.g01f02);
            if(!isAuthenticated)
            {
                return BadRequest("Login Failed");
            }
            else
            {
                return Ok("Login Successful");
            }
        }

        #endregion
    }
}
