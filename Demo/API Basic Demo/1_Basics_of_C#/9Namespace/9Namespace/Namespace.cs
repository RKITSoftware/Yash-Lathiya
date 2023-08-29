//namespace is mainly used to manage so many classes 

namespace MyNamespace
{
    class India
    {
        public static void sayHello()
        {
            Console.WriteLine("Hello from India");
        }
    }

    class America
    {
        public static void sayHello()
        {
            Console.WriteLine("Hello from America");
        }
    }

    // Nested Namespace

    namespace NestedNamespace
    {
        class NestedClass
        {
            public static void sayHello()
            {
                Console.WriteLine("Hello from nested namespace");
            }
        }
    }
}
