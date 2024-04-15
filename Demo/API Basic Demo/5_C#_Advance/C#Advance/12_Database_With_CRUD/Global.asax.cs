using Newtonsoft.Json;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace _12_Database_With_CRUD
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        #region Protected Method

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            ConfigureOrmLite();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Configures orm lite to connect mySql
        /// </summary>
        private void ConfigureOrmLite()
        {
            // Retrieve the connection string from json file ( Connection > ConnectionStrings.json)
            string jsonFilePath = @"C:\Users\yash.l\source\repos\Yash-Lathiya\Demo\API Basic Demo\5_C#_Advance\C#Advance\12_Database_With_CRUD\Connection\ConnectionString.json";
            var connectionStrings = File.ReadAllText(jsonFilePath);

            dynamic connectionStringObject = JsonConvert.DeserializeObject(connectionStrings);
            string server = connectionStringObject.ConnectionStrings.connectionString.Server;
            int port = connectionStringObject.ConnectionStrings.connectionString.Port;
            string database = connectionStringObject.ConnectionStrings.connectionString.Database;
            string userId = connectionStringObject.ConnectionStrings.connectionString["User Id"];
            string password = connectionStringObject.ConnectionStrings.connectionString.Passoword;

            string mysqlConnectionString = $"server={server};port={port};database={database};user={userId};password={password};";


            // Create an instance of OrmLiteConnectionFactory using the retrieved connection string
            var dbFactory = new OrmLiteConnectionFactory(mysqlConnectionString, MySqlDialect.Provider);

            // Store the IDbConnectionFactory instance in a static variable for application-wide usage
            Static.Static.OrmContext = dbFactory;

        }

        #endregion

    }
}
