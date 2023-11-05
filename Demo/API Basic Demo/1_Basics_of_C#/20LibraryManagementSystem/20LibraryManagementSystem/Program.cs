namespace _20LibraryManagementSystem
{
    class Program
    {
        /// <summary>
        /// implements task within library ..
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("--- Direct Method is accessed of Library ---");
            LibraryTest.RunTest();
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("--- Test Cases are passed from external file ---");
            LibraryTest.RunTestFromExternalFile();
            Console.WriteLine("------------------------------------------------");
        }
    }

}