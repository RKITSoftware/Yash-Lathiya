using ExpenseTracker.DL;
using ExpenseTracker.Models;
using ExpenseTracker.Models.DTO;
using ExpenseTracker.Models.POCO;
using ExpenseTracker.Security;
using Microsoft.IdentityModel.Tokens;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Consist Buisness Logic of all methods related to User
    /// </summary>
    public class BLUsr01Handler
    {
        #region Private Members

        /// <summary>
        /// POCO model of User
        /// </summary>
        private Usr01 _objUsr01;

        /// <summary>
        /// Db context of Usr01
        /// </summary>
        private readonly DbUsr01Context _objDbUsr01Context;

        /// <summary>
        /// Response to HTTP action method
        /// </summary>
        private Response _objResponse;
        #endregion

        #region Public Members

        /// <summary>
        /// Type of operation
        /// </summary>
        public EnmOperation operation;

        #endregion

        #region Constructor

        /// <summary>
        /// Get the MySqlConnection instance from the Connection class
        /// </summary>
        /// <exception cref="Exception"> If there is error in database connection process </exception>
        public BLUsr01Handler()
        {
            _objDbUsr01Context = new DbUsr01Context();
        }

        #endregion

        #region  Public Methods

        /// <summary>
        /// Converts DTO Model to POCO Model
        /// </summary>
        /// <param name="objDTOUsr01"> DTO Model of User </param>
        public void Presave(DTOUsr01 objDTOUsr01)
        {
            _objUsr01 = objDTOUsr01.ConvertModel<Usr01>();

            // Encrypt the password by using Aes Algorithm
            // Encrypted password will be stored in database
            AesAlgo aes = new AesAlgo();
            _objUsr01.R01f05 = aes.Encrypt(_objUsr01.R01f05);

            if (operation == EnmOperation.C)
            {
                // creation time
                _objUsr01.R01f06 = DateTime.Now;
            }
            else if(operation == EnmOperation.U)
            {
                // updation time
                _objUsr01.R01f07 = DateTime.Now;
            }
        }

        /// <summary>
        /// validate poco model
        /// </summary>
        /// <returns> object of response </returns>
        public Response Validate()
        {
            _objResponse = new Response();

            if(operation == EnmOperation.C)
            {
                // unique username
                if (IsUsernameExist(_objUsr01.R01f02))
                {
                    _objResponse.SetResponse(true, HttpStatusCode.BadRequest, " username already exists ", null);
                    return _objResponse;
                }

                // unique email id
                if (IsEmailExist(_objUsr01.R01f03))
                {
                    _objResponse.SetResponse(true, HttpStatusCode.BadRequest, " email-id already exists ", null);
                    return _objResponse;
                }

                // unique mobile number
                if (IsMobileExist(_objUsr01.R01f04))
                {
                    _objResponse.SetResponse(true, HttpStatusCode.BadRequest, " mobile number already exists ", null);
                    return _objResponse;
                }
            }

            if(operation == EnmOperation.U)
            {
                // unique username ( check all records except current one )
                if (IsUsernameExist(_objUsr01.R01f02, Common.GetUserIdFromClaims()))
                {
                    _objResponse.SetResponse(true, HttpStatusCode.BadRequest, " username already exists in the database ", null);
                    return _objResponse;
                }

                // unique email id ( check all records except current one )
                if (IsEmailExist(_objUsr01.R01f03, Common.GetUserIdFromClaims()))
                {
                    _objResponse.SetResponse(true, HttpStatusCode.BadRequest, " email-id already exists in the database ", null);
                    return _objResponse;
                }

                // unique mobile number ( check all records except current one )
                if (IsMobileExist(_objUsr01.R01f04, Common.GetUserIdFromClaims()))
                {
                    _objResponse.SetResponse(true, HttpStatusCode.BadRequest, " mobile number already exists in the database ", null);
                    return _objResponse;
                }
            }

            return _objResponse;
        }
        
        /// <summary>
        /// Save record in the database 
        /// </summary>
        /// <returns> object of response </returns>
        public Response Save()
        {
            _objResponse = new Response();

            if(operation == EnmOperation.C)
            {
                _objResponse = _objDbUsr01Context.AddUsr01(_objUsr01);

                string message = $"username : {_objUsr01.R01f02} \r\n mobile : {_objUsr01.R01f04}";
                // send mail to notify user id
                SendRegistrationEmail(message, _objUsr01.R01f03);

                _objResponse.SetResponse(" user added ", null);
                return _objResponse;
            }
            else if(operation == EnmOperation.U)
            {
                _objDbUsr01Context.UpdateUsr01(_objUsr01);

                _objResponse.SetResponse(" user updated ", null);
                return _objResponse;
            }

            return _objResponse;
        }

        /// <summary>
        /// To authenticate user 
        /// </summary>
        /// <param name="r01f01"> Username </param>
        /// <param name="r01f05"> Password </param>
        /// <returns> true -> if credential is correct
        ///           false -> if credential is incorrect </returns>
        public Response LoginUser(string r01f03,  string r01f05)
        {
            bool isAuthenticated;
            _objResponse = new Response();

            AesAlgo aes = new AesAlgo();
            r01f05 = aes.Encrypt(r01f05);
            
            using(var db = Common.OrmContext.OpenDbConnection())
            {
                isAuthenticated =  db.Exists<Usr01>(x => x.R01f03 == r01f03 && x.R01f05 == r01f05);
            }

            if (!isAuthenticated)
            {
                _objResponse.SetResponse(true, HttpStatusCode.Unauthorized, " invalid credential ", null);
                return _objResponse;
            }

            _objResponse.SetResponse("login successful", null);
            return _objResponse;
        }

        /// <summary>
        /// Generate Jwt token 
        /// Also add userId as claim 
        /// </summary>
        /// <param name="r01f03"> email id </param>
        /// <returns> Jwt token </returns>
        public Response GenerateJwtToken(string r01f03)
        {
            _objResponse = new Response();

            int r01f01;

            using(var db = Common.OrmContext.OpenDbConnection())
            {
                Usr01 objUsr01 = db.Single<Usr01>(usr => usr.R01f03 == r01f03);
                r01f01 = objUsr01.R01f01;
            }

            // Create a DataTable to hold the generated jwt token
            DataTable dtUsr01Token = new DataTable();
            dtUsr01Token.Columns.Add("token", typeof(string));

            // Logic of Jwt Token 

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("315a6e8435387977315a6e8435387977"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                // user id added as claim
                new Claim("r01f01", r01f01.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: "https://localhost:44303/",
                audience: "https://localhost:44303/",
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Token expiration time
                signingCredentials: credentials
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            dtUsr01Token.Rows.Add(jwtToken);

            _objResponse.SetResponse(" login successful, token generated", dtUsr01Token);
            return _objResponse;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Is username exists in database or not         
        /// </summary>
        /// <param name="r01f02"> username </param>
        /// <returns></returns>
        private bool IsUsernameExist(string r01f02)
        {
            using(var db = Common.OrmContext.OpenDbConnection())
            {
                return db.Exists<Usr01>(usr => usr.R01f02 == r01f02);
            }
        }

        /// <summary>
        /// Is username exists in database or not except current record of user        
        /// </summary>
        /// <param name="r01f02"> username </param>
        /// <param name="r01f02"> userid </param>
        /// <returns></returns>
        private bool IsUsernameExist(string r01f02, int r01f01)
        {
            using (var db = Common.OrmContext.OpenDbConnection())
            {
                return db.Exists<Usr01>(usr => usr.R01f02 == r01f02 && usr.R01f01 != r01f01);
            }
        }

        /// <summary>
        /// Is email id exists in database or not         
        /// </summary>
        /// <param name="r01f03"> email id </param>
        /// <returns></returns>
        private bool IsEmailExist(string r01f03)
        {
            using (var db = Common.OrmContext.OpenDbConnection())
            {
                return db.Exists<Usr01>(usr => usr.R01f03 == r01f03);
            }
        }

        /// <summary>
        /// Is email id exists in database or not except current record of user        
        /// </summary>
        /// <param name="r01f03"> email id </param>
        /// <param name="r01f01"> user id </param>
        /// <returns></returns>
        private bool IsEmailExist(string r01f03, int r01f01)
        {
            using (var db = Common.OrmContext.OpenDbConnection())
            {
                return db.Exists<Usr01>(usr => usr.R01f03 == r01f03 && usr.R01f01 != r01f01);
            }
        }

        /// <summary>
        /// Is mobile number exists in database or not         
        /// </summary>
        /// <param name="r01f03"> mobile number </param>
        /// <returns></returns>
        private bool IsMobileExist(long r01f04)
        {
            using (var db = Common.OrmContext.OpenDbConnection())
            {
                return db.Exists<Usr01>(usr => usr.R01f04 == r01f04);
            }
        }

        /// <summary>
        /// Is mobile number exists in database or not except current record of user               
        /// </summary>
        /// <param name="r01f04"> mobile number </param>
        /// <param name="r01f01"> user id </param>
        /// <returns></returns>
        private bool IsMobileExist(long r01f04, int r01f01)
        {
            using (var db = Common.OrmContext.OpenDbConnection())
            {
                return db.Exists<Usr01>(usr => usr.R01f04 == r01f04 && usr.R01f01 != r01f01);
            }
        }

        /// <summary>
        /// Sending userId on registered email
        /// </summary>
        /// <param name="userId"> In database (r01f01)</param>
        /// <param name="userEmail">In database (r01f03)</param>
        private void SendRegistrationEmail(string message, string userEmail)
        {
            try
            {
                string senderEmail = "expense_tracker@outlook.com";
                string senderPassword = "Expense@Tracker";
                string recipientEmail = userEmail;

                MailMessage mail = new MailMessage(senderEmail, recipientEmail)
                {
                    Subject = "Welcome to Expense Tracker !!",
                    Body = $"Thank you for registering! \r\n {message}"
                };

                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true
                };

                smtpClient.Send(mail);

                Console.WriteLine("Registration email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending registration email: {ex.Message}");
            }
        }

        #endregion

    }
}