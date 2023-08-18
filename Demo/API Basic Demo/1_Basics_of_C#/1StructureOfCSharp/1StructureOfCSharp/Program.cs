using MyFirstNamespace;
using System;

Console.WriteLine("Hello World !!");
Console.WriteLine("Starting Execution ...");

//Creating instance of Person class

Person person = new Person();
Console.WriteLine("First Name : " + person.Firstname);
Console.WriteLine("Last Name : " + person.LastName);

//Accessing Method of MyFirstClass

MyFirstClass.MainMethod();

//Creating instance of Structure

MyFirstStruct myStruct = new MyFirstStruct();
myStruct.Number = 7;
Console.WriteLine("Number : " + myStruct.Number);

//Accessing method of interface

MyFirstImplementation myInterface = new MyFirstImplementation();
myInterface.SayHello();

//Simple calculation by using delegate

MyFirstDelegate myDelegate = () => 10 * 5;
Console.WriteLine("Delegate Result : " + myDelegate());

//Accessing enum values

MyFirstEnum myEnum = MyFirstEnum.Value3;
Console.WriteLine("Enum Value 3 : " + myEnum);

namespace MyFirstNamespace
{
    class Person
    {
        internal String Firstname = "Yash";
        internal String LastName = "Lathiya";
    }
    class MyFirstClass
    {
        public static void MainMethod()
        {
            Console.WriteLine("Hello from Main method");
        }
    }

    struct MyFirstStruct
    {
        public int Number { get; set; }
    }

    interface IMyFirstInterface
    {
        void SayHello();
    }

    class MyFirstImplementation : IMyFirstInterface
    {
        public void SayHello()
        {
            Console.WriteLine("Heloo from Implementation");
        }
    }

    delegate int MyFirstDelegate();

    enum MyFirstEnum
    {
        Value1,
        Value2,
        Value3
    }

    namespace MyFirstNestedNamespace
    {
        struct NestedStruct
        {
            public double DoubleValue { get; set; }
        }
    }
}
