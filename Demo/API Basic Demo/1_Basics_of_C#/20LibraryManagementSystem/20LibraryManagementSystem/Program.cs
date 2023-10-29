using System.Data;
using System.Net;

namespace _20LibraryManagementSystem
{
    class Program
    {
        /// <summary>
        /// implements task within library ..
        /// </summary>
        static void Main(string[] args)
        {
            //LibraryTest.RunTest();

            LibraryTest.RunTestFromExternalFile();
        }
    }

    /// <summary>
    /// Implements Book Class which involves all properties of books
    /// </summary>
    class Book
    {
        private static int nextId = 1;
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
            DataTable booksTable = new DataTable ();

            booksTable.Columns.Add("BookId", typeof(int));
            booksTable.Columns.Add("Title", typeof(string));
            booksTable.Columns.Add("Author", typeof(string));
            booksTable.Columns.Add("IsAvailable", typeof(bool));

            foreach (var book in books)
            {
                DataRow newRow = booksTable.NewRow ();
                newRow["BookId"] = book.BookId;
                newRow["Title"] = book.Title;
                newRow["Author"] = book.Author;
                newRow["IsAvailable"] = book.IsAvailable;

                booksTable.Rows.Add (newRow);
            }

            Console.WriteLine("Current Status of Library : ");
            Console.WriteLine("BookId" + "\t" +"Title" + "\t" + "Author" + "\t" + "IsAvailable");
            foreach (DataRow row in booksTable.Rows)
            {
                Console.WriteLine(row["BookId"] + "\t" + row["Title"] + "\t" + row["Author"] + "\t" + row["IsAvailable"]);
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
            User user = users.FirstOrDefault(u => u.UserId == userId);

            if (user != null)
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
            User user = users.FirstOrDefault(u => u.UserId == userId);
            Book book = books.FirstOrDefault(b => b.BookId == bookId);

            if (book != null && user != null && book.IsAvailable)
            {
                user.CheckedOutItems.Add(bookId);
                book.IsAvailable = false;
                book.CheckedOutDate = DateTime.Now;
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

        /// <summary>
        /// It calculates amount which user have to pay..
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        public void CalculateBilling(int userId, int bookId)
        {
            User user = users.FirstOrDefault(u => u.UserId == userId);
            Book book = books.FirstOrDefault(b => b.BookId == bookId);

            if (book != null && user != null && !book.IsAvailable)
            {
                TimeSpan timeCheckedOut = DateTime.Now - book.CheckedOutDate;

                var totalSeconds = timeCheckedOut.TotalSeconds;
                var billingAmount = 5.0;

                for(int i=1; i<=totalSeconds; i++)
                {
                    if (i <= 1000)
                    {
                        billingAmount += 0.1;
                    }
                    else if(i > 1000 && i<= 2000)
                    {
                        billingAmount += 0.2;
                    }
                    else
                    {
                        billingAmount += 0.25;
                    }
                }

                Console.WriteLine("You have to pay " + billingAmount + " Rupees for the book " + book.Title);

            }
            else if(user == null)
            {
                Console.WriteLine("Users not found !!");
            }
            else if(book == null)
            {
                Console.WriteLine("Book not found");
            }
            else if(book.IsAvailable)
            {
                Console.WriteLine("Book is not checked out.");
            }
            else
            {
                Console.WriteLine("**");
            }
        }

        /// <summary>
        /// This methods implements logic of returning a book ..
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        public void ReturnBook(int userId, int bookId)
        {
            User user = users.FirstOrDefault(u => u.UserId == userId);
            Book book = books.FirstOrDefault(b => b.BookId == bookId);

            if (book != null && user != null && !book.IsAvailable && user.CheckedOutItems.Contains(bookId))
            {
                CalculateBilling(userId, bookId);

                user.CheckedOutItems.Remove(bookId);
                book.IsAvailable = true;

                Console.WriteLine(book.Title + "has been returned");
            }
            else if (user == null)
            {
                Console.WriteLine("User Not Found !!");
            }
            else if (book == null)
            {
                Console.WriteLine("Book Not Found !!");
            }
            else if (book.IsAvailable)
            {
                Console.WriteLine("Book is not checked out.");
            }
            else if (!user.CheckedOutItems.Contains(bookId))
            {
                Console.WriteLine("User has not checked out this book.");
            }
        }
        #endregion
    }

    /// <summary>
    /// Contains test cases to check implementation of library
    /// </summary>
    class LibraryTest
    {
        #region Public Methods

        /// <summary>
        /// simple code which contains issue and returning of book..
        /// </summary>
        public static void RunTest()
        {
            Library library = new Library();

            library.AddBook("Book_1", "Author_1");
            library.AddBook("Book_2", "Author_2");
            library.AddBook("Book_3", "Author_3");

            library.AddUser("Sachin Tendulkar");
            library.AddUser("Rohit Sharma");

            library.DisplayAllBooks();
            library.DisplayAvailableBooks();

            library.CheckedOutBook(1, 1);
            library.DisplayCheckedOutBooks(1);

            library.ReturnBook(1, 1);

            library.DisplayAvailableBooks();
            library.DisplayCheckedOutBooks(1);
        }

        /// <summary>
        /// Test Case from External File ..
        /// </summary>
        public static void RunTestFromExternalFile()
        {
            Library library = new Library();
            string[] testCases = File.ReadAllLines("D:\\RKIT\\Github Repo\\Demo\\API Basic Demo\\1_Basics_of_C#\\20LibraryManagementSystem\\20LibraryManagementSystem\\TestCases.txt");


            foreach (string testCase in testCases)
            {
                ProcessTestCase(library, testCase);
            }
        }

        /// <summary>
        /// How to execute single line of testcase ..
        /// </summary>
        /// <param name="library"></param>
        /// <param name="testCase"></param>
        public static void ProcessTestCase(Library library, string testCase)
        {
            string[] parts = testCase.Split(' ');
            string action = parts[0];

            switch(action)
            {
                case "AddBook":
                    library.AddBook(parts[1], parts[2]);
                    break;

                case "AddUser":
                    library.AddUser(parts[1]);
                    break;

                case "CheckOutBook":
                    int userId = int.Parse(parts[1]);
                    int bookId = int.Parse(parts[2]);
                    library.CheckedOutBook(userId, bookId);
                    break;

                case "DisplayAvailableBooks":
                    library.DisplayAvailableBooks();
                    break;

                case "DisplayCheckedOutBooks":
                    int displayUserId = int.Parse(parts[1]);
                    library.DisplayCheckedOutBooks(displayUserId);
                    break;

                case "ReturnBook":
                    int returnUserId = int.Parse(parts[1]);
                    int returnBookId = int.Parse(parts[2]);
                    library.ReturnBook(returnUserId, returnBookId);
                    break;

                default:
                    Console.WriteLine("Invalid test case: " + testCase);
                    break;
            }
        }

        #endregion
    }

}