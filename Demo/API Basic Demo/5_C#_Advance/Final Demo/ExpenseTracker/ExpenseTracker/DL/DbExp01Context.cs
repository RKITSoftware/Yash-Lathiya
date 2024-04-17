using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ExpenseTracker.DL
{
    /// <summary>
    /// Database logic related to Exp01 table
    /// </summary>
    public class DbExp01Context
    {
        #region Private Members

        /// <summary>
        /// Sql Connection
        /// </summary>
        private readonly MySqlConnection _mySqlConnection;

        #endregion

        #region Constructor

        /// <summary>
        /// establishes mysql connection 
        /// </summary>
        /// <exception cref="Exception"> if connection is not properly established </exception>
        public DbExp01Context()
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
        /// Get all expenses from database
        /// </summary>
        /// <param name="r01f01"> user id </param>
        /// <returns> Data table consisting expense details </returns>
        public DataTable GetExp01(int r01f01)
        {
            // Create a DataTable
            DataTable dtExp01 = new DataTable();

            // retrieve expense from the database in form of DataTable
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = String.Format(@"SELECT 
                                                        P01F01,
                                                        P01F03,
                                                        P01F05,
                                                        P01F06,
                                                        P01f07,
                                                        p01f08
                                                     FROM
                                                        EXP01
                                                     WHERE
                                                        P01F02 = {0}", r01f01);

                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    _mySqlConnection.Open();
                    adapter.Fill(dtExp01);
                }
                finally
                {
                    _mySqlConnection.Close();
                }
            }
            return dtExp01;
        }

        #endregion

    }
}