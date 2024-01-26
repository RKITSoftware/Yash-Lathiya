using ExpenseTracker.Models;
using MySql.Data.MySqlClient;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Consist Buisness Logic of all methods related to User
    /// </summary>
    public static class UserManager
    {
        #region Connect to Database

        private static MySqlConnection _mySqlConnection;

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
                command.Parameters.AddWithValue("@r01f05", objUsr01.r01f05);

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

        public static bool LoginUser(string r01f02,  string r01f05)
        {
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
                command.Parameters.AddWithValue("@r01f05", r01f05);

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