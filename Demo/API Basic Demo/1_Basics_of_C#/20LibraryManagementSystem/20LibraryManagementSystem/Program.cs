namespace _20LibraryManagementSystem
{
    class Program
    {
        /// <summary>
        /// implements task within library ..
        /// </summary>
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddBook("Book 1", "Author 1");
            library.AddBook("Book 2", "Author 2");
            library.AddBook("Book 3", "Author 3");

            library.AddUser("John Doe");
            library.AddUser("Jane Doe");

            library.DisplayAvailableBooks();

            library.CheckedOutBook(1, 2);

            library.DisplayCheckedOutBooks(1);
        }
    }

    /// <summary>
    /// Performs all operation of library over books
    /// </summary>
    class Library
    {
        private List<Book> books = new List<Book> ();

        private List<User> users = new List<User> ();

        #region Public Methods

        /// <summary>
        /// Adds a book in library
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        public void AddBook(string title, string author)
        {
            books.Add(new Book { Title = title, Author = author }); 
        }

        /// <summary>
        /// Adds a user in library
        /// </summary>
        /// <param name="userName"></param>
        public void AddUser(string userName)
        {
            users.Add(new User { UserId = users.Count + 1, UserName = userName });
        }

        /// <summary>
        /// Display details of all books in library
        /// </summary>
        public void DisplayAllBooks()
        {
            Console.WriteLine("Books : ");
            foreach (var book in books)
            {
                Console.WriteLine("Titile : " + book.Title + ", Author : " + book.Author);
            }
        }

        /// <summary>
        /// Display details of all available books in library
        /// </summary>
        public void DisplayAvailableBooks()
        {
            Console.WriteLine("Available Books : ");
            foreach(var book in books)
            {
                if (book.IsAvailable)
                {
                    Console.WriteLine("Titile : " + book.Title + ", Author : " + book.Author);
                }
            }
        }

        /// <summary>
        /// Display CheckedOutBooks for particular UserId
        /// </summary>
        /// <param name="userId"></param>
        public void DisplayCheckedOutBooks(int userId)
        {
            User user = users[userId];
            
            if(user != null)
            {
                Console.WriteLine("Checked Out Items for " + user.UserName);

                foreach(var bookId in user.CheckedOutItems)
                {
                    Book book = books[bookId];

                    if(book != null)
                    {
                        Console.WriteLine(book.BookId + " " + book.Title + " by " + book.Author);
                    }

                }
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }

        /// <summary>
        /// Perform checkedOutBook operation .. 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        public void CheckedOutBook(int userId, int bookId)
        {
            User user = users[userId];

            Book book = books[bookId];

            if(book != null && user != null && book.IsAvailable)
            {
                user.CheckedOutItems.Add(bookId);
                book.IsAvailable = false;
                Console.WriteLine(book.Title + "has been checked out.");
            }
            else if(user == null)
            {
                Console.WriteLine("User Not Found !!");
            }
            else if(book == null)
            {
                Console.WriteLine("Book Not Found !!");
            }
            else
            {
                Console.WriteLine("Item is already checked out .");
            }
        }
        #endregion
    }

    /// <summary>
    /// Implements Book Class which involves all properties of books
    /// </summary>
    class Book
    {
        #region Public Methods

        /// <summary>
        /// Get, Set Method for Id
        /// </summary>
        public string BookId { get; set; }

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

        #endregion
    }

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