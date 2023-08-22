//Statements

//Declaration Statements

using System.Reflection.Emit;

string firstName = "Yash";
string lastName;
const long aadharCardNumber = 382467184713;

//Expression Statements

lastName = "Lathiya";
Console.WriteLine();

//Goto Statements

void additionalMethod()
{
    if (true) goto label;

    label:
    ; //Empty Statement
}

//Embedded Statements

for(int i = 0; i< 10; i++)
{
    //Statements within { } block --> Embedded Statements
}

//Nested Statements

for(int i = 0;i< 10; i++)
{
    for(int j = 0;j< i; j++)
    {
        Console.Write("*");
        if(i == j) // always i > j 
        {
            Console.Write("Will Never Print"); //Unreachable Statement
        }
    }
    Console.WriteLine();
}
