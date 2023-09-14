class StringDemostration
{
    #region Methods
    static void Main(string[] args)
    {
        StringCreation();

        StringMethods(); 
    }
    /// <summary>
    /// Different ways to institiate a string ..
    /// </summary>
    static void StringCreation()
    {
        string string1 = "Hello, I'm String";

        char[] charArray = { 'h', 'e', 'l', 'l', 'o', ' ', 'I', 'm', ' ', 'Y', 'a', 's', 'h', ' ', 'L', 'a', 't', 'h', 'i', 'y', 'a' };
        string string2 = new string(charArray);

        string path1 = "C:\\Yash\\RKIT\\Demo";

        string path2 = @"C:\Yash\RKIT\Demo";

        string string3 = null;
        string3 = path2;

        Console.WriteLine(string1);
        Console.WriteLine(string2);
        Console.WriteLine(path1);
        Console.WriteLine(path2);
        Console.WriteLine(string3);
    }
    /// <summary>
    /// String's different methods
    /// </summary>
    static void StringMethods()
    {
        BasicMethods();
    }
    /// <summary>
    /// Basic String Methods
    /// </summary>
    static void BasicMethods()
    {
        string string1 = "Hello, I'm String";

        //Length of string

        Console.WriteLine(string1.Length);

        //toLower & toUpper Methods

        Console.WriteLine(string1.ToLower());
        Console.WriteLine(string1.ToUpper());

        //Concatination

        string string2 = "Hello from Yash Lathiya too !!";
        string myString = string1 + " " + string2;
        string myString1 = string.Concat(string1, string2, myString);

        Console.WriteLine(myString);
        Console.WriteLine(myString1);

        //indexOf method --> returns first occurance

        Console.WriteLine(myString.IndexOf("l"));

        //Access single character from string

        Console.WriteLine(myString[5]);

        //substring

        string subString = myString.Substring(0, 5);
        Console.WriteLine(subString);

        //join method

        string[] myWords = { "Hello", "I am", "String" };
        string myStringFromWords = string.Join("_", myWords);
        Console.WriteLine(myStringFromWords);

        //Contains method

        bool containsYash = myString.Contains("Yash");
        Console.WriteLine(containsYash);

        //Replace Method

        string replacedString = myString.Replace("Yash Lathiya", "Sachin Tendulkar");
        Console.WriteLine(replacedString);

        string fruits = "     banana, mangoes, oranges    ";

        //trim method --> removes spaces from starting and ending

        fruits = fruits.Trim();
        Console.WriteLine(fruits);

        //Split method

        string[] fruitsArray = fruits.Split(",");
        
        foreach(string fruit in fruitsArray)
        {
            Console.Write(fruit);
        }
        Console.WriteLine();

        //Compare method

        string apple = "apple";
        string banana = "banana";

        Console.WriteLine(string.Compare(apple, banana)); //a comes before b -> (-ve) values
    }

    #endregion
}