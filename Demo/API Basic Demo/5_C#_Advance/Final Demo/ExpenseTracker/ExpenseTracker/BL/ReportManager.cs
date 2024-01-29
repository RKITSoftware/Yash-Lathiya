using ExpenseTracker.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

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
            List<Exp01> lstExp01 = new List<Exp01>();
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
                            lstExp01.Add(new Exp01() { p01f01 = Convert.ToInt32(reader["p01f01"]),
                                                       p01f02 = p01f02,
                                                       p01f03 = Convert.ToDecimal(reader["p01f03"]),
                                                       p01f04 = Convert.ToDateTime(reader["p01f04"]),
                                                       p01f05 = Convert.ToString(reader["p01f05"]),
                                                       p01f06 = Convert.ToString(reader["p01f06"])
                            });
                            reportContent += $"Expense Id : {reader["p01f01"]}, \t Amount : {reader["p01f03"]}, \t Time : {reader["p01f04"]}, \t Category : {reader["p01f05"]}, \t Description : {reader["p01f06"]}  \r\n";
                        }
                    }
                }
                catch(Exception ex)
                {
                    reportContent = ex.Message;
                }
                finally
                {
                    _mySqlConnection.Close();
                }
            }

            // Save the report content to a file
            string filePath = "C:\\Users\\yash.l\\source\\repos\\Yash-Lathiya\\Demo\\API Basic Demo\\5_C#_Advance\\Final Demo\\ExpenseTracker\\ExpenseTracker\\Report\\report.txt";
            System.IO.File.WriteAllText(filePath, reportContent);

            // Serialize List of objects to string
            // Purpose  : To store that data in database

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string serializedReportData = javaScriptSerializer.Serialize(lstExp01);

            using(MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = @"INSERT INTO 
                                            rep01 
                                            (p01f02) 
                                        VALUES (@p01f02)";
                command.Parameters.AddWithValue("@p01f02", serializedReportData);

                try
                {
                    _mySqlConnection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    _mySqlConnection.Close();
                }
            }

            return filePath;
        }
    }
}