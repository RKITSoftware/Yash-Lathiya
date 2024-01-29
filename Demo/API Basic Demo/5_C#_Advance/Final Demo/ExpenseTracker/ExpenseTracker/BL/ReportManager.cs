using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Consist Buisness Logic of all methods related to Report
    /// </summary>
    public static class ReportManager
    {
        #region Connect to Database

        private static MySqlConnection _mySqlConnection;

        static ReportManager()
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

        public static string GenerateReport(int p01f02)
        {
            // For demonstration purposes, let's assume the report is a text file
            string reportContent = "";

            using(MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = @"SELECT
                                            p01f01,
                                            p01f03,
                                            p01f04,
                                            p01f05,
                                            p01f06
                                        FROM 
                                            exp01
                                        WHERE
                                            p01f02 = @p01f02";

                command.Parameters.AddWithValue("@p01f02", p01f02);

                try
                {
                    _mySqlConnection.Open();

                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reportContent += $"Expense Id : {reader["p01f01"]}, \t Amount : {reader["p01f03"]}, \t Time : {reader["p01f04"]}, \t Category : {reader["p01f05"]}, \t Description : {reader["p01f06"]}  \r\n";
                        }
                    }
                }
                catch(Exception ex)
                {
                    reportContent = "report can not be generated due to error : " + ex.Message;
                }
                finally
                {
                    _mySqlConnection.Close();
                }
            }

            // Save the report content to a file
            string filePath = "C:\\Users\\yash.l\\source\\repos\\Yash-Lathiya\\Demo\\API Basic Demo\\5_C#_Advance\\Final Demo\\ExpenseTracker\\ExpenseTracker\\Report\\report.txt";
            System.IO.File.WriteAllText(filePath, reportContent);
            
            return filePath;
        }
    }
}