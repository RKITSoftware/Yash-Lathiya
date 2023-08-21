class Arrays
{
    static void Main()
    {
        //Declare array with elements
        int[] array1 = { 1, 2, 3 };
        int[] array2 = new int[] { 1, 2, 3 };

        //Declaration of array without assigning elements
        int[] array3 = new int[3];

        //Multi Dimensional Array (Tabular Format of Data)
        int[,] multiDimensionalArray1 = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] multiDimensionalArray2 = new int[2, 3];

        //Jagged Array (Sub-arrays can have different length)
        string[][] jaggedArray = new string[2][];
        jaggedArray[0] = new string[3] { "a", "b", "c" };
        jaggedArray[1] = new string[4];
        jaggedArray[1][0] = "a";
        jaggedArray[1][1] = "b";
        jaggedArray[1][2] = "c";
        Console.WriteLine(jaggedArray[1][3]); //prints null (if int --> prints 0)
        jaggedArray[1][3] = "d";

        //Jagged Array declaration with values
        int[][] anotherJaggedArray =
        {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5,},
            new int[] { 6 }
        };


        //Array Methods

        //Length of Array
        Console.WriteLine("jaggedArray Length : "+jaggedArray.Length);

        //GetLength is used for finding length of array at specific dimension
        Console.WriteLine("multiDimensionalArray2.GetLength(0) : "+multiDimensionalArray2.GetLength(0));
        Console.WriteLine("multiDimensionalArray2.GetLength(1) : "+multiDimensionalArray2.GetLength(1));

        //Rank of array
        Console.WriteLine("multiDimensionalArray1 Rank : " + multiDimensionalArray1.Rank);

        //ForEach Loop
        foreach (int i in multiDimensionalArray1)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine();
        foreach (string[] row in jaggedArray)
        {
            foreach (string elements in row)
            {
                Console.Write(elements + " ");
            }
        }

        //Reverse array
        Array.Reverse(array1);
        Console.WriteLine();
        foreach(int i in array1)
        {
            Console.Write(i+" ");   
        }

        //Implicitly-typed Arrays in Object Initializers
        //(Array of Objects)
        var objects = new[]
        {
            new
            {
                firstName = "Yash",
                lastName = "Lathiya"
            },
            new
            {
                firstName = "Sachin",
                lastName = "Tendulkar"
            }
        };
        Console.WriteLine();
        foreach(object o in objects)
        {
            Console.WriteLine(o);
        }

    }
}