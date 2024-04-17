//using ExpenseTracker.Models;
//using MySql.Data.MySqlClient;
//using System;

//namespace ExpenseTracker.DL
//{
//    /// <summary>
//    /// Database logic related to Rep02 class
//    /// </summary>
//    public class DbRep02Context
//    {
//        #region Private Members

//        /// <summary>
//        /// Sql Connection
//        /// </summary>
//        private readonly MySqlConnection _mySqlConnection;

//        /// <summary>
//        /// Response of HTTP Action method
//        /// </summary>
//        private Response _objResponse;

//        #endregion

//        #region Constructor

//        /// <summary>
//        /// establishes mysql connection 
//        /// </summary>
//        /// <exception cref="Exception"> if connection is not properly established </exception>
//        public DbRep02Context()
//        {
//            try
//            {
//                _mySqlConnection = Connection.DatabaseConnection.GetMySqlConnection();
//            }
//            catch (Exception ex)
//            {
//                throw new Exception(ex.Message);
//            }
//        }

//        #endregion
//    }
//}