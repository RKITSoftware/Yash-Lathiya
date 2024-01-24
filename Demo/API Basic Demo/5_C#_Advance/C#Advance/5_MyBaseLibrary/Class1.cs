using System;
using System.Collections.Generic;
namespace _5_MyBaseLibrary
{
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
