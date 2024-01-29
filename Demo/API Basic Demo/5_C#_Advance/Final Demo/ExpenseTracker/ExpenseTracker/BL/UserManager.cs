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
        #region Private Members

        private static MySqlConnection _mySqlConnection;
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
 
        public static void RegisterUser(Usr01 objUsr01 )
        {
            // Mobile Number must contain 10 digits

            if (!IsMobileNumber(objUsr01.r01f04))
            {
                throw new Exception(" Mobile Number is invalid ");
            }

            // Encrypt the password by using Aes Algorithm

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

        private static bool IsMobileNumber(long r01f04)
        {
            Regex mobileNumberPattern = new Regex(@"\d{10}");
            Match match = mobileNumberPattern.Match(r01f04.ToString());
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        public static bool LoginUser(string r01f02,  string r01f05)
        {
            AesAlgo aes = new AesAlgo();
            _encryptedPassword = aes.Encrypt(r01f05);

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
    }
}