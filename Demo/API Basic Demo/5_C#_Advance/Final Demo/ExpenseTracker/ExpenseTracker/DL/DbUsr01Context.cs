using ExpenseTracker.BL;
using ExpenseTracker.Models;
using ExpenseTracker.Models.POCO;
using MySql.Data.MySqlClient;
using System;

namespace ExpenseTracker.DL
{
    /// <summary>
    /// consists database logic of Usr01 model
    /// </summary>
    public class DbUsr01Context
    {
        #region Private Members

        /// <summary>
        /// Sql Connection
        /// </summary>
        private readonly MySqlConnection _mySqlConnection;

        /// <summary>
        /// Response of HTTP Action method
        /// </summary>
        private Response _objResponse;

        #endregion

        #region Constructor

        /// <summary>
        /// establishes mysql connection 
        /// </summary>
        /// <exception cref="Exception"> if connection is not properly established </exception>
        public DbUsr01Context()
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

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds user details in usr01
        /// </summary>
        /// <param name="objUsr01"> object of usr01 model </param>
        /// <returns> object of response </returns>
        public Response AddUsr01(Usr01 objUsr01)
        {
            _objResponse = new Response();

            // Add user in database
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = String.Format(@"INSERT INTO 
                                                        USR01 
                                                            (r01f02, r01f03, r01f04, r01f05, r01f06) 
                                                        VALUES 
                                                            ('{0}', '{1}', {2}, '{3}', '{4}')",
                                        objUsr01.R01f02,
                                        objUsr01.R01f03,
                                        objUsr01.R01f04,
                                        objUsr01.R01f05,
                                        objUsr01.R01f06.ToString("yyyy-MM-dd hh-mm-ss"));

                try
                {
                    _mySqlConnection.Open();

                    command.ExecuteNonQuery();

                    _objResponse.SetResponse("user added", null);
                    return _objResponse;
                }
                finally
                {
                    _mySqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// update user in database 
        /// </summary>
        /// <param name="objUsr01"> object of user</param>
        /// <returns> object of response </returns>
        public Response UpdateUsr01(Usr01 objUsr01)
        {
            _objResponse = new Response();

            // Update user in the database
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = String.Format(@"UPDATE USR01 
                                    SET r01f02 = '{0}', 
                                        r01f03 = '{1}', 
                                        r01f04 = {2}, 
                                        r01f05 = '{3}', 
                                        r01f07 = '{4}'
                                    WHERE r01f01 = {5}",
                                    objUsr01.R01f02,
                                    objUsr01.R01f03,
                                    objUsr01.R01f04,
                                    objUsr01.R01f05,
                                    objUsr01.R01f07.ToString("yyyy-MM-dd hh-mm-ss"),
                                    Common.GetUserIdFromClaims());

                try
                {
                    _mySqlConnection.Open();
                    command.ExecuteNonQuery();

                    _objResponse.SetResponse("user updated", null);
                    return _objResponse;
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