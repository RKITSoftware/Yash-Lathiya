using _5_MyBaseLibrary;

namespace _5_1_Uses_My_Base_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");

            List<int> myList = list.ToIntList();

            foreach(int i in myList)
            {
                Console.WriteLine(i);
            }
        }
    }
}