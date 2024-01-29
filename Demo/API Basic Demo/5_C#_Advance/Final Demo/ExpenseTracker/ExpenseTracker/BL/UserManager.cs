using ExpenseTracker.Models;
using ExpenseTracker.Security;
using MySql.Data.MySqlClient;
using System;
using System.Text.RegularExpressions;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Consist Buisness Logic of all methods related to User
    /// </summary>
    public static class UserManager
    {
        #region Private Static Members

        // Sql Connection
        private static MySqlConnection _mySqlConnection;

        // For Security Purpose
        private static string _encryptedPassword;

        static UserManager()
        {
            try
            {
                // Get the MySqlConnection instance from the Connection class
                _mySqlConnection = Connection.DatabaseConnection.GetMySqlConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// To Register user i database
        /// </summary>
        /// <param name="objUsr01"> Object of User </param>
        /// <exception cref="Exception"> If Mobile Number is not Valid ..</exception>
        public static void RegisterUser(Usr01 objUsr01 )
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
        public static bool IsMobileNumber(long r01f04)
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
        public static bool LoginUser(string r01f02,  string r01f05)
        {
            AesAlgo aes = new AesAlgo();
            _encryptedPassword = aes.Encrypt(r01f05);

            // Compare encrypted password to encrypted password 
            using(MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = @"SELECT
                                            r01f02,
                                            r01f05
                                        FROM
                                            usr01
                                        WHERE
                                            r01f02 = @r01f02 and 
                                            r01f05 = @r01f05";

                command.Parameters.AddWithValue("@r01f02", r01f02);
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

        #endregion
    }
}