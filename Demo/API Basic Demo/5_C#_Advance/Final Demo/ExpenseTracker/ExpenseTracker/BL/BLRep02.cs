using ExpenseTracker.DL;
using ExpenseTracker.Models.POCO;
using MySql.Data.MySqlClient;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Consist Buisness Logic of all methods related to Report
    /// </summary>
    public class BLRep02
    {
        #region Private Members

        /// <summary>
        /// user id retrieved from current user context
        /// </summary>
        private readonly int _r01f01 = Common.GetUserIdFromClaims();

        #endregion
        
        #region Public Methods

        /// <summary>
        /// Generates report which includes credit & Expense
        /// </summary>
        /// <returns> Path of file which contains this data </returns>
        public string GenerateReport()
        {
            // Report Content 
            StringBuilder reportContent = new StringBuilder("***** Expense *****\r\n");

            DbExp01Context objDbExp01Context = new DbExp01Context();
            DataTable dtExp01 = objDbExp01Context.GetExp01(_r01f01);

            // Add Expense table headings
            reportContent.AppendLine("P01F01\tP01F03\tP01F05\tP01F06");
            foreach (DataRow row in dtExp01.Rows)
            {
                // Append each row's values to the reportContent StringBuilder
                foreach (var item in row.ItemArray)
                {
                    reportContent.Append(item.ToString()).Append("\t"); // Assuming tab-separated values
                }
                reportContent.AppendLine(); // Add a new line after each row
            }

            DbCre01Context objDbCre01Context = new DbCre01Context();
            DataTable dtCre01 = objDbCre01Context.GetCre01(_r01f01);

            reportContent.AppendLine("***** Credit *****");
            // Add Credit table headings
            reportContent.AppendLine("P01F01\tP01F03\tP01F05\tP01F06");
            foreach (DataRow row in dtCre01.Rows)
            {
                // Append each row's values to the reportContent StringBuilder
                foreach (var item in row.ItemArray)
                {
                    reportContent.Append(item.ToString()).Append("\t"); // Assuming tab-separated values
                }
                reportContent.AppendLine(); // Add a new line after each row
            }

            // Add entry in database
            using(var db = Common.OrmContext.OpenDbConnection())
            {
                db.Insert<Rep02>(new Rep02()
                {
                    P02f02 = reportContent.ToString()
                });
            }

            // Save the report content to a file
            string filePath = "C:\\Users\\yash.l\\source\\repos\\Yash-Lathiya\\Demo\\API Basic Demo\\5_C#_Advance\\Final Demo\\ExpenseTracker\\ExpenseTracker\\Report\\report.txt";
            System.IO.File.WriteAllText(filePath, reportContent.ToString());

            return filePath;
        }

        #endregion

    }
}