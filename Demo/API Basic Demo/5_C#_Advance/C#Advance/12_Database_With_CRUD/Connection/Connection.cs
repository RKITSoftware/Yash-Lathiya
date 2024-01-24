using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;


namespace _12_Database_With_CRUD.Connection
{
    /// <summary>
    /// Provides Mysql connection to this web api 
    /// </summary>
    public static class Connection
    {
        static MySqlConnection _mySqlConnection;
        /// <summary>
        /// Connect to database by MySql String 
        /// </summary>
        static Connection()
        {
            try
            {
                // Extracting Connection String 

                string jsonFilePath = @"C:\Users\yash.l\source\repos\Yash-Lathiya\Demo\API Basic Demo\5_C#_Advance\C#Advance\12_Database_With_CRUD\Connection\ConnectionString.json";
                var connectionStrings = File.ReadAllText(jsonFilePath);

                dynamic connectionStringObject = JsonConvert.DeserializeObject(connectionStrings);
                string server = connectionStringObject.ConnectionStrings.connectionString.Server;
                int port = connectionStringObject.ConnectionStrings.connectionString.Port;
                string database = connectionStringObject.ConnectionStrings.connectionString.Database;
                string userId = connectionStringObject.ConnectionStrings.connectionString["User Id"];
                string password = connectionStringObject.ConnectionStrings.connectionString.Passoword;

                string mysqlConnectionString = $"server={server};port={port};database={database};user={userId};password={password};";

                // Providing Connection string to mySqlConnection
                _mySqlConnection = new MySqlConnection(mysqlConnectionString);
                //_mySqlConnection.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Get the MySQL connection instance
        /// </summary>
        public static MySqlConnection GetMySqlConnection()
        {
            return _mySqlConnection;
        }
    }
}