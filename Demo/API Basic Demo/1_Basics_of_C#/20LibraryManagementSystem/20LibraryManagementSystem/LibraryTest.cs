using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20LibraryManagementSystem
{
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
            
            //string[] testCases = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "TestCases.txt");

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

            //Implement method of library as per given command
            switch (action)
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

                case "DisplayAllBooks":
                    library.DisplayAllBooks();
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
