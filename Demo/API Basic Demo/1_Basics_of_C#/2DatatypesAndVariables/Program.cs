class Program
{
    //Class level scope starts

    string classLevelScope = "Class Level Scope Variable";

    static void method()
    {
        //Method level scope starts

        string methodLevelScope = "Method Level Scope Variable";
        Console.WriteLine(methodLevelScope);

        {
            //Block level scope starts

            string blockLevelScope = "Block Level Scope Variable";
            Console.WriteLine(blockLevelScope);

            //Block level scope ends
        }

        //Method level scope ends
    }

    static void datatypes() {

        //Datatypes

        int numberInt = 5; // 4 bytes
        Console.WriteLine(numberInt);

        long numberLong = 111111111111111111L; // 8 bytes
        Console.WriteLine(numberLong);

        float numberFloat = 1.11f; // 4 bytes
        Console.WriteLine(numberFloat);

        double numberDouble = 1.11111111111111d; // 8 bytes
        Console.WriteLine(numberDouble);

        bool numberBool = false;
        Console.WriteLine(numberBool);

        char character = 'a';
        Console.WriteLine(character);

        string s = "I am string";
        Console.WriteLine(s);

    }

    static void typeCasting()
    {
        int randomInt = 73;
        double randomDouble = 77.77;

        //Explicit Type Conversion

        //Conversion into string
        Console.WriteLine((Convert.ToString(randomInt)).GetType());
        //Conversion into double
        Console.WriteLine((Convert.ToDouble(randomInt)).GetType());

        //Implicit Type Conversion
        Console.WriteLine((int)randomDouble); //Floor Value
        Console.WriteLine(Convert.ToInt32(randomDouble)); //Mathematical Value

    }

    static void Main(string[] args)
    {
        method();
        datatypes();
        typeCasting();

        Program program = new Program();
        Console.WriteLine(program.classLevelScope);
    }

    //Class level scope ends
}





