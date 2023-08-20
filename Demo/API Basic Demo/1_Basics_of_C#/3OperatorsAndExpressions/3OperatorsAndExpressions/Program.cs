class Program
{
    static void Main(string[] args)
    {
        operators();
        expressions();
    }

    static void operators()
    {
        arithmeticOperator();
        comparisonOperator();
        booleanLogicalOperator();
        bitwiseAndShiftOperator();
        equalityOperator();
    }

    static void arithmeticOperator()
    {
        Console.WriteLine("................");
        Console.WriteLine("Arithmetic Operators");
        int numberInt = 7;
        double numberDouble = 7.7;
        Console.WriteLine(numberInt++); //postfix increment
        Console.WriteLine(numberDouble++); //postfix increment
        Console.WriteLine(++numberDouble); //prefix increment
        Console.WriteLine(--numberInt); //prefix decrement
        Console.WriteLine(73 % 7); //reminder
        numberInt *= 7;
        Console.WriteLine(numberInt); //compount assignment
        Console.WriteLine(int.MaxValue); //maximum value
        Console.WriteLine(double.IsInfinity(1.0 / 0.0)); //isInfinity method
    }

    static void comparisonOperator()
    {
        Console.WriteLine("................");
        Console.WriteLine("Comparison Operators");
        Console.WriteLine(7.7 < 8.8); // less than operator
        Console.WriteLine(7.7 > 8.8); // greater than operator
        Console.WriteLine(7.7 <= 8.8); // Less than or equal operator
        Console.WriteLine(7.7 >= 8.8); // greater than or equal operator
    }
    static void booleanLogicalOperator()
    {
        Console.WriteLine("................");
        Console.WriteLine("Boolean Logical Operators");
        Console.WriteLine(true | false); //Logical OR
        Console.WriteLine(true ^ false); //Logical XOR
        Console.WriteLine(true & false); //Logical AND
        Console.WriteLine(true || false); //Conditional Logical OR
        Console.WriteLine(true && false); //Conditional Logical AND
    }
    static void bitwiseAndShiftOperator()
    {
        Console.WriteLine("................");
        Console.WriteLine("Bitwise & Shift Operators");
        byte b = 37;
        Console.WriteLine(Convert.ToString(b, toBase:2));
        Console.WriteLine(Convert.ToString(~b, toBase: 2)); // complement
        Console.WriteLine(Convert.ToString(b << 3, toBase: 2)); // left shift 3 times
        Console.WriteLine(Convert.ToString(b >> 3, toBase: 2)); // right shift 3 times
    }
    static void equalityOperator()
    {
        Console.WriteLine("................");
        Console.WriteLine("Equality Operators");
        Console.WriteLine(5 == '5'); //Equality Operator
        Console.WriteLine(5 == 5); //Equality Operator
        Console.WriteLine(5 != '5'); //Equality Operator
    }

    static void expressions()
    {
        //Interpoleted String Expressions
        string firstName = "Yash";
        string lastName = "Lathiya";
        var age = 21;
        Console.WriteLine($"First Name : {firstName} , Last Name : {lastName}, age : {age}");

        int[] numbers = { 1, 2, 3, 4, 5, 6 };

        //Lambda Expressions
        var maximumCube = numbers.Max( x => x*x*x );
        Console.WriteLine(maximumCube);

        //Query Expressions
        int[] values = { 1, 2, 3, 4, 5, 6 };
        IEnumerable<int> query = from value in values where value > 3 orderby value select value;
        Console.WriteLine(string.Join(" ", query));
    }
}