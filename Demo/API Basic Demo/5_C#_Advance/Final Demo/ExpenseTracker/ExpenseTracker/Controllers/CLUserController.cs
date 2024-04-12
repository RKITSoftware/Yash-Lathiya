using ExpenseTracker.BL;
using ExpenseTracker.Models;
using ExpenseTracker.Models.DTO;
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
        #region Private Members
        
        /// <summary>
        /// BL logic for User Manager 
        /// </summary>
        private readonly BLUserManager _objBLUserManager;

        #endregion

        #region Constructor

        /// <summary>
        /// consists BL logic for User Manager
        /// </summary>
        public CLUserController()
        {
             _objBLUserManager = new BLUserManager();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To Register User in database 
        /// </summary>
        /// <param name="objUsr01"> Object of User </param>
        /// <returns> Success Message if Registered Successfully </returns>
        [HttpPost]
        [Route("api/User/Register")]
        public IHttpActionResult RegisterUser([FromBody] DTOUsr01 objDTOUsr01) 
        {
            // presave
            _objBLUserManager.Presave(objDTOUsr01);

            // validate 
            bool isValid = _objBLUserManager.Validate();
            if (!isValid)
            {
                return BadRequest("Requested data is not valid");
            }

            // add
            _objBLUserManager.Save(Static.Operation.Create);

            return Ok("User Registered");
        }

        /// <summary>
        /// To Login User with help of userid and password 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("api/User/Login")]
        public IHttpActionResult LoginUser([FromBody] DTOLog01 objDTOLog01) 
        {
            bool isAuthenticated = _objBLUserManager.LoginUser(objDTOLog01.G01f01, objDTOLog01.G01f02);
            if(!isAuthenticated)
            {
                return BadRequest("Login Failed");
            }
            else
            {
                // Generate Jwt token
                var token = _objBLUserManager.GenerateJwtToken(objDTOLog01.G01f01); 
                return Ok(new { Token = token, Message = "Login Successful" });
            }
        }

        #endregion
    }
}
