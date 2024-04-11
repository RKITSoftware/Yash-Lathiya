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
        #region Private Members 

        /// <summary>
        /// ORM lite database connection factory 
        /// </summary>
        private readonly IDbConnectionFactory dbFactory;

        #endregion

        #region Constructor

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
            Dictionary<String, object> dictionary = new Dictionary<string, object>();

            // Loop through properties of objExp01
            foreach (var prop in typeof(Cre01).GetProperties())
            {
                // don't update and creation time
                if (prop.Name == "e01f05")
                {
                    continue;
                }

                var value = prop.GetValue(objCre01);
                if (value != null)
                {
                    dictionary.Add(prop.Name, value);
                }
            }

            using (var db = dbFactory.OpenDbConnection())
            {
                db.UpdateOnly<Cre01>(
                    dictionary,       // Specify the field to update
                    x => x.e01f01 == objCre01.e01f01); // Filter condition to set expense id 
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
                // Check if the user is authorized to delete the expense
                int _r01f01 = Static.Static.GetUserIdFromClaims();
                db.Delete<Cre01>(x => x.e01f01 == e01f01 && x.e01f02 == _r01f01);
            }
        }

        #endregion
    }
}