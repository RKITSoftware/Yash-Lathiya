using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20LibraryManagementSystem
{
    /// <summary>
    /// Implements Book Class which involves all properties of books
    /// </summary>
    class Book
    {
        /// <summary>
        /// Will provide this ID to Book
        /// </summary>
        int nextId = 1;

        /// <summary>
        /// Constructor which initilaize book by giving ID
        /// </summary>
        public Book()
        {
            BookId = nextId;
            nextId++;
        }

        #region Public Methods

        /// <summary>
        /// Get, Set Method for Id
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Get, Set Method for Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Get, Set Method for Author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Get, Set Method for Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Book is available or not , intitially book is available
        /// </summary>
        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// It stores the exact time when book is given to user
        /// </summary>
        public DateTime CheckedOutDate { get; set; }

        #endregion
    }

}
