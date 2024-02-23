using ExpenseTracker.Models;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;

namespace ExpenseTracker.ORM
{
    /// <summary>
    /// Provides ORM Service to Credit CRE01 class in database
    /// </summary>
    public class CreditService
    {
        #region dbFactory Configuration 

        private readonly IDbConnectionFactory dbFactory;

        /// <summary>
        /// Constructor which allows to set current instance of database to select
        /// </summary>
        /// <param name="dbFactory"></param>
        /// <exception cref="ArgumentNullException"> If context is null </exception>
        public CreditService(IDbConnectionFactory dbFactory)
        {
            this.dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add credit in database
        /// </summary>
        /// <param name="objCre01"></param>
        public void AddCredit(Cre01 objCre01)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                db.Insert(objCre01);
            }
        }

        /// <summary>
        /// Get vall credit details for specific user
        /// </summary>
        /// <param name="e01f02"> User Id </param>
        /// <returns> List of credit details </returns>
        public List<Cre01> GetAllCredits(int e01f02)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                List<Cre01> allCredits = db.Select<Cre01>(credit => credit.e01f02.Equals(e01f02));
                return allCredits;
            }
        }

        /// <summary>
        /// Update Credit details
        /// </summary>
        /// <param name="objCre01"> Object of new Credit deatils </param>
        public void UpdateCredit(Cre01 objCre01)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                db.Update(objCre01);
            }
        }

        /// <summary>
        /// To delete credit detail from the database
        /// </summary>
        /// <param name="e01f01"> Credit Id </param>
        public void DeleteCredit(int e01f01)
        {
            using (var db = dbFactory.OpenDbConnection())
            {
                Cre01 objCre01 = db.SingleById<Cre01>(e01f01);
                if(objCre01.e01f02 == Static.Static.GetUserIdFromClaims())
                {
                    db.DeleteById<Cre01>(e01f01);
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