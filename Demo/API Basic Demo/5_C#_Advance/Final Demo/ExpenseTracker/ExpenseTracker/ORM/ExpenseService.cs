using ExpenseTracker.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.ORM
{
    public class ExpenseService
    {
        #region dbFactory Configuration 

        private readonly IDbConnectionFactory dbFactory;

        /// <summary>
        /// Constructor which allows to set current instance of database to select
        /// </summary>
        /// <param name="dbFactory"></param>
        /// <exception cref="ArgumentNullException"> If context is null </exception>
        public ExpenseService(IDbConnectionFactory dbFactory)
        {
            this.dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        #endregion

        public void AddExpense(Exp01 objExp01)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                db.Insert(objExp01);
            }
        }

        public Exp01 GetExpense(int p01f02, DateTime p01f04)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                var objExp01 = db.Single<Exp01>(expense => expense.p01f02 == p01f02 && expense.p01f04.Equals(p01f04));
                return objExp01;
            }
        }

        public List<Exp01> GetAllExpense(int p01f02)
        {
            using(var db = dbFactory.OpenDbConnection())
            {
                List<Exp01> allExpense = db.Select<Exp01>();
                return allExpense;
            }
        }

        public void UpdateExpense(Exp01 exp01)
        {
            using(var db = dbFactory.OpenDbConnection())
            {
                db.Update(exp01);
            }
        }

        public void DeleteExpense(int p01f01)
        {
            using(var db = dbFactory.OpenDbConnection())
            {
                db.DeleteById<Exp01>(p01f01);
            }

        }
    }
}