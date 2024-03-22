using Dependency_Injection.Interfaces;
using Dependency_Injection.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Dependency_Injection.Services
{
    /// <summary>
    /// Provides MySql srevice which implements product service 
    /// </summary>
    public class MySqlProductService : IProductService
    {
        #region dbFactory setup 

        private IDbConnectionFactory _dbFactory;

        /// <summary>
        /// Setup Orm lite connection
        /// </summary>
        /// <param name="configuration"></param>
        public MySqlProductService(IConfiguration configuration)
        {   
            var connectionString = ExtractMySqlConnectionString(configuration);

            this._dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add product in database 
        /// </summary>
        /// <param name="objPro01"> object of product </param>
        public void AddProduct(Pro01 objPro01)
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                db.Insert(objPro01);
            }
        }

        /// <summary>
        /// Get all Products in database
        /// </summary>
        /// <returns> All products in database </returns>
        public List<Pro01> GetAllProducts()
        {
            using (var db = _dbFactory.OpenDbConnection())
            {
                return db.Select<Pro01>();
            }
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Extract MySql connection string from appSetting.json file
        /// </summary>
        /// <param name="configuration"> Configuration </param>
        /// <returns> MySql connection string </returns>
        private string ExtractMySqlConnectionString(IConfiguration configuration)
        {
            var server = configuration["ConnectionStrings:MySqlConnection:Server"];
            var port = configuration["ConnectionStrings:MySqlConnection:Port"];
            var database = configuration["ConnectionStrings:MySqlConnection:Database"];
            var userId = configuration["ConnectionStrings:MySqlConnection:User Id"];
            var password = configuration["ConnectionStrings:MySqlConnection:Password"];

            return $"Server={server};Port={port};Database={database};Uid={userId};Pwd={password};";
        }

        #endregion

    }
}
