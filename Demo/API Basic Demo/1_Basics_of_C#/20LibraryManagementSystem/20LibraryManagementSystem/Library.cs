using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20LibraryManagementSystem
{
    /// <summary>
    /// Performs all operation of library over books
    /// </summary>
    class Library
    {
        /// <summary>
        /// List of Book
        /// </summary>
        List<Book> books;

        /// <summary>
        /// List of Users
        /// </summary>
        List<User> users = new List<User>();

        #region Public Methods

        /// <summary>
        /// Adds a book in library
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        public void AddBook(string title, string author)
        {
            books = new List<Book>();
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
            DataTable booksTable = new DataTable();

            booksTable.Columns.Add("BookId", typeof(int));
            booksTable.Columns.Add("Title", typeof(string));
            booksTable.Columns.Add("Author", typeof(string));
            booksTable.Columns.Add("IsAvailable", typeof(bool));

            foreach (Book book in books)
            {
                DataRow newRow = booksTable.NewRow();
                newRow["BookId"] = book.BookId;
                newRow["Title"] = book.Title;
                newRow["Author"] = book.Author;
                newRow["IsAvailable"] = book.IsAvailable;

                booksTable.Rows.Add(newRow);
            }

            Console.WriteLine("Current Status of Library : ");
            Console.WriteLine("BookId" + "\t\t" + "Title" + "\t\t" + "Author" + "\t\t" + "IsAvailable");
            foreach (DataRow row in booksTable.Rows)
            {
                Console.WriteLine(row["BookId"] + "\t\t" + row["Title"] + "\t\t" + row["Author"] + "\t\t" + row["IsAvailable"]);
            }


        }

        /// <summary>
        /// Display details of all available books in library
        /// </summary>
        public void DisplayAvailableBooks()
        {
            Console.WriteLine("Available Books : ");
            foreach (Book book in books)
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

                foreach (var bookId in user.CheckedOutItems)
                {
                    Book book = books.FirstOrDefault(b => b.BookId == bookId);

                    if (book != null)
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
            else if (user == null)
            {
                Console.WriteLine("User Not Found !!");
            }
            else if (book == null)
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

                for (int i = 1; i <= totalSeconds; i++)
                {
                    if (i <= 1000)
                    {
                        billingAmount += 0.1;
                    }
                    else if (i > 1000 && i <= 2000)
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
            else if (user == null)
            {
                Console.WriteLine("Users not found !!");
            }
            else if (book == null)
            {
                Console.WriteLine("Book not found");
            }
            else if (book.IsAvailable)
            {
                Console.WriteLine("Book is not checked out.");
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
}
