using MyNamespace;
using MyNamespace.NestedNamespace;

class MainClass
{
    public static void Main(String[] args)
    {
        //Reference of MyNamespace --> Namespace.cs

        India.sayHello();
        America.sayHello();
        NestedClass.sayHello();

        //Reference of another project --> 7OOP

        //FullStackDeveloper fullStackDeveloper = new FullStackDeveloper();
    }
}
