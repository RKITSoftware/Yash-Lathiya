using ExpenseTracker.Models;
using ExpenseTracker.Security;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Consist Buisness Logic of all methods related to User
    /// </summary>
    public class BLUserManager
    {
        #region Private Members

        // Sql Connection
        private MySqlConnection _mySqlConnection;

        // For Security Purpose
        private string _encryptedPassword;

        #endregion

        #region Public Methods

        /// <summary>
        /// Get the MySqlConnection instance from the Connection class
        /// </summary>
        /// <exception cref="Exception"> If there is error in database connection process </exception>
        public BLUserManager()
        {
            try
            {
                _mySqlConnection = Connection.DatabaseConnection.GetMySqlConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// To Register user i database
        /// </summary>
        /// <param name="objUsr01"> Object of User </param>
        /// <exception cref="Exception"> If Mobile Number is not Valid ..</exception>
        public void RegisterUser(Usr01 objUsr01 )
        {
            // Mobile Number must contain 10 digits

            if (!IsMobileNumber(objUsr01.r01f04))
            {
                throw new Exception(" Mobile Number is invalid ");
            }

            // Encrypt the password by using Aes Algorithm
            // Encrypted password will be stored in database
            AesAlgo aes = new AesAlgo();
            _encryptedPassword = aes.Encrypt(objUsr01.r01f05);

            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = @"INSERT INTO 
                                            USR01 
                                            (r01f01, r01f02, r01f03, r01f04, r01f05) 
                                        VALUES (@r01f01, @r01f02, @r01f03, @r01f04, @r01f05)";

                command.Parameters.AddWithValue("@r01f01", objUsr01.r01f01);
                command.Parameters.AddWithValue("@r01f02", objUsr01.r01f02);
                command.Parameters.AddWithValue("@r01f03", objUsr01.r01f03);
                command.Parameters.AddWithValue("@r01f04", objUsr01.r01f04);
                command.Parameters.AddWithValue("@r01f05", _encryptedPassword);

                try
                {
                    _mySqlConnection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    _mySqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Checks is Mobile number contsins 10 digits or not 
        /// </summary>
        /// <param name="r01f04"> Mobile Number </param>
        /// <returns> true for valid mobile number otherwise invalid </returns>
        public bool IsMobileNumber(long r01f04)
        {
            // Regex pattern to check length of digits 
            Regex mobileNumberPattern = new Regex(@"\d{10}");

            Match match = mobileNumberPattern.Match(r01f04.ToString());
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// To authenticate user 
        /// </summary>
        /// <param name="r01f02"> Username </param>
        /// <param name="r01f05"> Password </param>
        /// <returns> true -> if credential is correct
        ///           false -> if credential is incorrect </returns>
        public bool LoginUser(int r01f01,  string r01f05)
        {
            AesAlgo aes = new AesAlgo();
            _encryptedPassword = aes.Encrypt(r01f05);

            // Compare encrypted password to encrypted password 
            using(MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = @"SELECT
                                            r01f01,
                                            r01f05
                                        FROM
                                            usr01
                                        WHERE
                                            r01f01 = @r01f01 and 
                                            r01f05 = @r01f05";

                command.Parameters.AddWithValue("@r01f01", r01f01);
                command.Parameters.AddWithValue("@r01f05", _encryptedPassword);

                try 
                {
                    _mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Login successful
                            return true;
                        }
                        else
                        {
                            // Login failed
                            return false;
                        }
                    }
                }

                catch (Exception ex)
                {
                    // Handle any exceptions, e.g., log or throw
                    Console.WriteLine("Error during login: " + ex.Message);
                    return false;
                }

                finally
                {
                    _mySqlConnection.Close();
                }

            }
        }

        public string GenerateJwtToken(int r01f01)
        {
            // Add your JWT generation logic here
            // Include claims, expiration, signing key, etc.

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("315a6e8435387977315a6e8435387977"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("r01f01", r01f01.ToString()),
                // Add additional claims as needed
            };

            var token = new JwtSecurityToken(
                issuer: "https://localhost:44303/",
                audience: "https://localhost:44303/",
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Token expiration time
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}