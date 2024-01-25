using System.Collections.Generic;
namespace _5_MyBaseLibrary
{
    /// <summary>
    /// This is library which converts string to int items in list
    /// </summary>
    public static class Class1
    {
        public static List<int> ToIntList(this List<string> lst)
        {
            List<int> list = new List<int>();
            foreach (var lstItem in lst)
            {
                list.Add(int.Parse(lstItem));
            }

            return list;
        }
    }
}
