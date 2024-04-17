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
            dtCre01.Columns.Add("E01f01", typeof(int));
            dtCre01.Columns.Add("E01f03", typeof(decimal));
            dtCre01.Columns.Add("E01f04", typeof(string));
            dtCre01.Columns.Add("E01f05", typeof(DateTime));
            dtCre01.Columns.Add("E01f06", typeof(DateTime)).AllowDBNull = true ;

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
                    _mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are rows to read
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Create a new row in the DataTable and fill it with data from the reader
                                DataRow row = dtCre01.NewRow();
                                row["E01f01"] = reader.GetInt32(0);
                                row["E01f03"] = reader.GetDecimal(1);
                                row["E01f04"] = reader.GetString(2);
                                row["E01f05"] = reader.GetDateTime(3);
                                row["E01f06"] = reader.IsDBNull(4) ? DBNull.Value: (object)reader.GetDateTime(4);
                                dtCre01.Rows.Add(row);
                            }
                        }
                    }
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