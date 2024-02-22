using ExpenseTracker.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;

namespace ExpenseTracker.ORM
{
    /// <summary>
    /// Provides ORM Service to Expense EXP01 class in database
    /// </summary>
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

        #region Public Methods

        /// <summary>
        /// Add Expense in database
        /// </summary>
        /// <param name="objExp01"> Object of expense </param>
        public void AddExpense(Exp01 objExp01)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                db.Insert(objExp01);
            }
        }

        /// <summary>
        /// Get list of expense by user id and time of expense 
        /// </summary>
        /// <param name="p01f02"> User Id </param>
        /// <param name="p01f04">DateTime of Expense </param>
        /// <returns> List of Expense</returns>
        public List<Exp01> GetExpense(int p01f02, DateTime p01f04)
        {
          
            using (var db = dbFactory.OpenDbConnection())
            {
                var lstExp01 = db.Select<Exp01>(expense => expense.p01f02 == p01f02 && expense.p01f04.Equals(p01f04));
                return lstExp01;
            }
   
        }

        /// <summary>
        /// Get all expense for specic user
        /// </summary>
        /// <param name="p01f02"> User Id </param>
        /// <returns>List of Expense </returns>
        public List<Exp01> GetAllExpense(int p01f02)
        {
            using(var db = dbFactory.OpenDbConnection())
            {
                List<Exp01> allExpense = db.Select<Exp01>(expense => expense.p01f02.Equals(p01f02));
                return allExpense;
            }
        }

        /// <summary>
        /// To update expense in the database
        /// </summary>
        /// <param name="objExp01"> Object of new details </param>
        public void UpdateExpense(Exp01 objExp01)
        {
            using(var db = dbFactory.OpenDbConnection())
            {
                db.Update(objExp01);
            }
        }

        /// <summary>
        /// Delete Expense from the database
        /// </summary>
        /// <param name="p01f01"> Expense Id </param>
        public void DeleteExpense(int p01f01)
        {
            using(var db = dbFactory.OpenDbConnection())
            {
                Exp01 objExp01 = db.SingleById<Exp01>(p01f01);
                if (objExp01.p01f02 == Static.Static.GetUserIdFromClaims())
                {
                    db.DeleteById<Exp01>(p01f01);
                }
                else
                {
                    throw new Exception("You can delete only yours credit entry");
                }
                
            }

        }

        #endregion
    }
}