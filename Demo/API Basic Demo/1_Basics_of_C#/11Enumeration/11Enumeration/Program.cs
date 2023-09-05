//Enumeration is special class which contains constants..
class Enumeration
{
    #region Enumerations

    //Declare Enum
    enum Days
    {
        Monday,     //0
        Tuesday,    //1 
        Wednesday,  //2
        Thursday,   //3
        Friday,     //4
        Saturday,   //5
        Sunday      //6
    }

    enum Currency{
        Rupees = 100,
        Doller,
        Yen = 500,
        Dehram
    }

    #endregion

    /// <summary>
    /// IDemonstate of basic operations with enumeration..
    /// </summary>
    static void Main(string[] args)
    {
        //Accessing Enum Values

        Console.WriteLine(Days.Monday);
        Console.WriteLine((int)Days.Tuesday);

        Console.WriteLine(Currency.Rupees);
        Console.WriteLine((int)Currency.Dehram);

        //Traversing Enum

        //here enumItem is string 
        foreach(string enumItem in Enum.GetNames(typeof(Currency)))
        {
            Console.WriteLine(enumItem);
        }

        //here enumItem is constant itself
        foreach (Currency enumItem in Enum.GetValues(typeof(Currency)))
        {
            Console.WriteLine(enumItem + " = " + (int)enumItem);
        }

        //Unchangeble --> throws error
        //Currency.Yen = 602;
    }
}
