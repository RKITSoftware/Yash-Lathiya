using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20LibraryManagementSystem
{
    /// <summary>
    /// Implements User Class which has information about user and Issued Books
    /// </summary>
    class User
    {
        #region Public Methods

        /// <summary>
        /// Get, Set Method for Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Get, Set Method for Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Contains book details which are checkedOut
        /// </summary>
        public List<int> CheckedOutItems { get; set; } = new List<int>();

        #endregion
    }
}
