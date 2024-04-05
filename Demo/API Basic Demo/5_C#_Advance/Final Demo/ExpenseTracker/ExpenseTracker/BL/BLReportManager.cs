﻿using ExpenseTracker.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Consist Buisness Logic of all methods related to Report
    /// </summary>
    public class BLReportManager
    {
        #region Private Members

        private MySqlConnection _mySqlConnection;

        // user id retrieved from current user context
        private int _r01f01 = Static.Static.GetUserIdFromClaims();

        #endregion

        #region Public Methods

        public BLReportManager()
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

        /// <summary>
        /// Generates report which includes credit & Expense
        /// </summary>
        /// <returns> Path of file which contains this data </returns>
        public string GenerateReport()
        {
            // list of Expense & Credit 
            List<Exp01> lstExp01 = new List<Exp01>();
            List<Cre01> lstCre01 = new List<Cre01>();

            // Report Content 
            string reportContent = "***** Expense *****\r\n";

            // Add expense in list & reportContent 
            using(MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = @"SELECT
                                            p01f01,
                                            p01f03,
                                            p01f07,
                                            p01f05,
                                            p01f06
                                        FROM 
                                            exp01
                                        WHERE
                                            p01f02 = @p01f02";

                command.Parameters.AddWithValue("@p01f02", _r01f01);

                try
                {
                    _mySqlConnection.Open();

                    using(MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstExp01.Add(new Exp01() { p01f01 = Convert.ToInt32(reader["p01f01"]),
                                                       p01f03 = Convert.ToDecimal(reader["p01f03"]),
                                                       p01f07 = Convert.ToDateTime(reader["p01f07"]),
                                                       p01f05 = Convert.ToString(reader["p01f05"]),
                                                       p01f06 = Convert.ToString(reader["p01f06"])
                            });
                            reportContent += $"Expense Id : {reader["p01f01"]}, \t " +
                                             $"Amount : {reader["p01f03"]}, \t " +
                                             $"Category : {reader["p01f05"]}, \t " +
                                             $"Description : {reader["p01f06"]}, \t" +
                                             $"Time : {reader["p01f07"]}, \r\n ";
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

            reportContent += "***** Credit *****\r\n";

            // Add credit in list & reportContent 
            using (MySqlCommand command = new MySqlCommand())
            {
                command.Connection = _mySqlConnection;
                command.CommandText = @"SELECT
                                            e01f01,
                                            e01f05,
                                            e01f03,
                                            e01f04
                                        FROM 
                                            cre01
                                        WHERE
                                            e01f02 = @p01f02";

                command.Parameters.AddWithValue("@p01f02", _r01f01);

                try
                {
                    _mySqlConnection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lstCre01.Add(new Cre01()
                            {
                                e01f01 = Convert.ToInt32(reader["e01f01"]),
                                e01f05 = Convert.ToDateTime(reader["e01f05"]),
                                e01f03 = Convert.ToDecimal(reader["e01f03"]),
                                e01f04 = Convert.ToString(reader["e01f04"]),

                            });
                            reportContent += $"Credit Id : {reader["e01f01"]}, \t " +
                                             $"Credit Amount : {reader["e01f03"]}, \t " +
                                             $"Description : {reader["e01f04"]},  \t" +
                                             $"Credit Time : {reader["e01f05"]}\r\n ";
                        }
                    }
                }
                catch (Exception ex)
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
            // Purpose  : To store that data in database ( REP01 class )

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string serializedExpenseData = javaScriptSerializer.Serialize(lstExp01);
            string serializedCreditData = javaScriptSerializer.Serialize(lstCre01);

            // Combine Credit & Expense data which will be stored in database
            string serializedReportData = serializedCreditData + serializedExpenseData;

            using (MySqlCommand command = new MySqlCommand())
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

        #endregion

    }
}