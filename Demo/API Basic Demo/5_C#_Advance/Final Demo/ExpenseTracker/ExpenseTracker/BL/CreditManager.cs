using ExpenseTracker.Models;
using ExpenseTracker.ORM;
using System.Collections.Generic;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// CreditManager class performs CRUD operation with Cre01 class by using ORM ( CreditService )
    /// </summary>
    public static class CreditManager
    {
        #region Static Members

        // To use Credit Service 
        private static CreditService _objCreditService;
        // To assign dbFactory
        static CreditManager()
        {
            _objCreditService = new CreditService(MyAppDbConnectionFactory.Instance);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add Credit details by using CreditService
        /// </summary>
        /// <param name="objCre01"> Object of Credit Model </param>
        public static void AddCredit(Cre01 objCre01)
        {
            _objCreditService.AddCredit(objCre01);
        }

        /// <summary>
        /// Get all credit details for specific user
        /// </summary>
        /// <param name="e01f02"> User Id </param>
        /// <returns> List of Credit detail for that userId</returns>
        public static List<Cre01> GetAllCredit(int e01f02)
        {
            return _objCreditService.GetAllCredits(e01f02);
        }

        /// <summary>
        /// Update Credit details 
        /// </summary>
        /// <param name="objCre01"> object of new credit details </param>
        public static void UpdateCredit(Cre01 objCre01)
        {
            _objCreditService.UpdateCredit(objCre01);
        }

        /// <summary>
        /// Delete credit detail from the database
        /// </summary>
        /// <param name="e01f01"> Credit Id </param>
        public static void DeleteCredit(int e01f01)
        {
            _objCreditService.DeleteCredit(e01f01);
        }

        #endregion
    }
}