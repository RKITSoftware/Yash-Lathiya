using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using _9_ORM_Tool.Connection;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;

namespace _9_ORM_Tool
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Configuration of Orm Lite
            ConfigureOrmLite();
        }

        /// <summary>
        /// Configures orm lite to connect mySql
        /// </summary>
        private void ConfigureOrmLite()
        {
            // Retrieve the connection string from the configuration file (Web.config)
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            // Create an instance of OrmLiteConnectionFactory using the retrieved connection string
            var dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);

            // Set the default dialect provider for OrmLite to MySQL
            OrmLiteConfig.DialectProvider = MySqlDialect.Provider;

            // Store the IDbConnectionFactory instance in a static variable for application-wide usage
            MyAppDbConnectionFactory.Instance = dbFactory;

        }
    }
}
