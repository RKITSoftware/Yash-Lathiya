using ExpenseTracker.Models;
using ExpenseTracker.ORM;
using System.Collections.Generic;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// CreditManager class performs CRUD operation with Cre01 class by using ORM ( CreditService )
    /// </summary>
    public class BLCreditManager
    {
        #region Private Members

        // To use Credit Service 
        private CreditService _objCreditService;

        // user id retrieved from current user context
        private int _r01f01 = Static.Static.GetUserIdFromClaims();

        #endregion

        #region Public Members

        // To assign dbFactory
        public BLCreditManager()
        {
            _objCreditService = new CreditService(MyAppDbConnectionFactory.Instance);
        }

        /// <summary>
        /// Add Credit details by using CreditService
        /// </summary>
        /// <param name="objCre01"> Object of Credit Model </param>
        public void AddCredit(Cre01 objCre01)
        {
            // Updating userId in object 
            objCre01.e01f02 = _r01f01;

            _objCreditService.AddCredit(objCre01);
        }

        /// <summary>
        /// Get all credit details for specific user
        /// </summary>
        /// <returns> List of Credit detail for that userId</returns>
        public List<Cre01> GetAllCredit()
        {
            return _objCreditService.GetAllCredits(_r01f01);
        }

        /// <summary>
        /// Update Credit details 
        /// </summary>
        /// <param name="objCre01"> object of new credit details </param>
        public void UpdateCredit(Cre01 objCre01)
        {
            // Updating userId in object 
            objCre01.e01f02 = _r01f01;

            _objCreditService.UpdateCredit(objCre01);
        }

        /// <summary>
        /// Delete credit detail from the database
        /// </summary>
        /// <param name="e01f01"> Credit Id </param>
        public void DeleteCredit(int e01f01)
        {
            _objCreditService.DeleteCredit(e01f01);
        }

        #endregion
    }
}