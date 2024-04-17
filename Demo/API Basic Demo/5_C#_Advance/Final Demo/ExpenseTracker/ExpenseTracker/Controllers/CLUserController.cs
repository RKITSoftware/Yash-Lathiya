using ExpenseTracker.BL;
using ExpenseTracker.Filters;
using ExpenseTracker.Models;
using ExpenseTracker.Models.DTO;
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
        private readonly BLUsr01 _objBLUsr01;

        /// <summary>
        /// object of response
        /// </summary>
        private Response _objResponse;
        #endregion

        #region Constructor

        /// <summary>
        /// consists BL logic for User Manager
        /// </summary>
        public CLUserController()
        {
             _objBLUsr01 = new BLUsr01();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To Register User in database 
        /// </summary>
        /// <param name="objDTOUsr01"> DTO Object of User </param>
        /// <returns> object of response </returns>
        [HttpPost]
        [ValidateModel]
        [Route("api/User/Register")]
        public IHttpActionResult RegisterUser([FromBody] DTOUsr01 objDTOUsr01) 
        {
            _objBLUsr01.operation = Operation.Create;

            // presave
            _objBLUsr01.Presave(objDTOUsr01);

            // validate 
            _objResponse = _objBLUsr01.Validate();
            if (!_objResponse.HasError)
            {
                // add
                _objResponse = _objBLUsr01.Save();
            }

            return Ok(_objResponse);
        }

        /// <summary>
        /// To update User in database 
        /// </summary>
        /// <param name="objDTOUsr01"> DTO Object of User </param>
        /// <returns> object of response </returns>
        [Authorize]
        [HttpPut]
        [ValidateModel]
        [Route("api/User/Update")]
        public IHttpActionResult UpdateUser([FromBody] DTOUsr01 objDTOUsr01)
        {
            _objBLUsr01.operation = Operation.Update;

            // presave
            _objBLUsr01.Presave(objDTOUsr01);

            // validate 
            _objResponse = _objBLUsr01.Validate();
            if(!_objResponse.HasError)
            {
                // update
                _objResponse = _objBLUsr01.Save();
            }

            return Ok(_objResponse);
        }

        /// <summary>
        /// To Login User with help of userid and password 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateModel]
        [Route("api/User/Login")]
        public IHttpActionResult LoginUser([FromBody] DTOLog01 objDTOLog01) 
        {
            _objResponse = _objBLUsr01.LoginUser(objDTOLog01.G01f01, objDTOLog01.G01f02);
            
            // valid credential
            if(!_objResponse.HasError)
            {
                // Generate Jwt token
                _objResponse = _objBLUsr01.GenerateJwtToken(objDTOLog01.G01f01);
                return Ok(_objResponse);
            }

            // invalid credential
            return Ok(_objResponse);
        }

        #endregion
    }
}
