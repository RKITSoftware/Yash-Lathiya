using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace ExpenseTracker.DL
{
    /// <summary>
    /// Database logic related to Cre01 table
    /// </summary>
    public class DbCre01Context
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
        public DbCre01Context()
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
        /// Get all credits from database
        /// </summary>
        /// <param name="r01f01"> user id </param>
        /// <returns> Data table consisting expense details </returns>
        public DataTable GetCre01(int r01f01)
        {
            // Create a DataTable
            DataTable dtCre01 = new DataTable();
            //string yash = String.Format(@"where r01f03 != {0}", )


            // retrieve credit from the database in form of datatable
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = String.Format(@"SELECT 
                                                        E01F01,
                                                        E01F03,
                                                        E01F04,
                                                        E01F05,
                                                        E01f06
                                                     FROM
                                                        CRE01
                                                     WHERE
                                                        E01F02 = {0}", r01f01);

                try
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    _mySqlConnection.Open();
                    adapter.Fill(dtCre01);
                }
                finally
                {
                    _mySqlConnection.Close();
                }
            }
            return dtCre01;
        }

        #endregion

    }
}