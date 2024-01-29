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

            // To use overriden list

            MySortedList<string> lst = new MySortedList<string>();
            lst.Add("yash");
            lst.Add("Prajval");
            lst.Add("Arnab");
            lst.Add("NewItem");
            lst.Add("Aayesha");

            lst.Remove("NewItem");

            foreach(string item in lst)
            {
                Console.WriteLine(item);
            }
        }
    }
}