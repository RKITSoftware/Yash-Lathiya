using _9_ORM_Tool.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;

namespace _9_ORM_Tool.Connection
{
    /// <summary>
    /// Employee Service which operates eith database ( ORM )
    /// </summary>
    public class EmployeeService
    {
        #region dbFactory Configuration 

        private readonly IDbConnectionFactory dbFactory;

        /// <summary>
        /// Constructor which allows to set current instance of database to select
        /// </summary>
        /// <param name="dbFactory"></param>
        /// <exception cref="ArgumentNullException"> If context is null </exception>
        public EmployeeService(IDbConnectionFactory dbFactory)
        {
            this.dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add employee in database 
        /// </summary>
        /// <param name="objEmp01"></param>
        public void AddEmployee(Emp01 objEmp01)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                db.Insert(objEmp01);
            }
        }

        /// <summary>
        /// Get Employee Details
        /// </summary>
        /// <param name="p01f01"></param>
        /// <returns></returns>
        public Emp01 GetEmployeeById(int p01f01)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                return db.SingleById<Emp01>(p01f01);
            }
        }

        /// <summary>
        /// Update Employee Details
        /// </summary>
        /// <param name="objEmp01"> details which will be updated </param>
        public void UpdateEmployee(Emp01 objEmp01)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                db.Update(objEmp01);
            }
        }

        /// <summary>
        /// To dlete Employee in the database
        /// </summary>
        /// <param name="p01f01"></param>
        public void DeleteEmployee(int p01f01)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                db.DeleteById<Emp01>(p01f01);
            }
        }

        #endregion
    }
}