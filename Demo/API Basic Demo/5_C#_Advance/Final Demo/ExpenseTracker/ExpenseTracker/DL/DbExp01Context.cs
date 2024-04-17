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
            dtExp01.Columns.Add("P01f01", typeof(int));
            dtExp01.Columns.Add("P01f03", typeof(decimal));
            dtExp01.Columns.Add("P01f05", typeof(string));
            dtExp01.Columns.Add("P01f06", typeof(string));
            dtExp01.Columns.Add("P01f07", typeof(DateTime));
            dtExp01.Columns.Add("P01f08", typeof(DateTime)).AllowDBNull = true;

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
                    _mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are rows to read
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Create a new row in the DataTable and fill it with data from the reader
                                DataRow row = dtExp01.NewRow();
                                row["P01F01"] = reader.GetInt32(0); 
                                row["P01F03"] = reader.GetDecimal(1);
                                row["P01F05"] = reader.GetString(2); 
                                row["P01F06"] = reader.GetString(3);
                                row["P01F07"] = reader.GetDateTime(4);
                                row["P01F08"] = reader.IsDBNull(5) ? DBNull.Value : (object)reader.GetDateTime(5); 
                                dtExp01.Rows.Add(row);
                            }
                        }
                    }
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