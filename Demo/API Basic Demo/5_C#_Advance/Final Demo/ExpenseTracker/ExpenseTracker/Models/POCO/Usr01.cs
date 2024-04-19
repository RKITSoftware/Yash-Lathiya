using ServiceStack.DataAnnotations;
using System;

namespace ExpenseTracker.Models.POCO
{
    /// <summary>
    /// Model of User 
    /// </summary>
    [Alias("Usr01")]
    public class Usr01
    {
        #region Public Members

        /// <summary>
        /// User Id
        /// </summary>
        [PrimaryKey]
        public int R01f01 { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        public string R01f02 { get; set; }

        /// <summary>
        /// User Email Id
        /// </summary>
        public string R01f03 { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        public long R01f04 { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string R01f05 { get; set; }

        /// <summary>
        /// User Creation Time
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime R01f06 { get; set; }

        /// <summary>
        /// User Updation Time
        /// </summary>
        [IgnoreOnInsert]
        public DateTime R01f07 { get; set; }

        #endregion
    }
}