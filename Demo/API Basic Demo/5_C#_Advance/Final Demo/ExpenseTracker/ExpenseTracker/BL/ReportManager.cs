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

        public static string GenerateReport()
        {
            // For demonstration purposes, let's assume the report is a text file
            string reportContent = "Sample report content.";

            // Save the report content to a file
            string filePath = "C:\\Users\\yash.l\\source\\repos\\Yash-Lathiya\\Demo\\API Basic Demo\\5_C#_Advance\\Final Demo\\ExpenseTracker\\ExpenseTracker\\Report\\report.txt";
            System.IO.File.WriteAllText(filePath, reportContent);
            
            return filePath;
        }
    }
}