using MyNamespace;
using MyNamespace.NestedNamespace;

class MainClass
{
    public static void Main(String[] args)
    {
        //Reference of MyNamespace --> Namespace.cs

        India.SayHello();
        America.SayHello();
        NestedClass.SayHello();

        //Reference of another project --> 7OOP

        //FullStackDeveloper fullStackDeveloper = new FullStackDeveloper();
    }
}
