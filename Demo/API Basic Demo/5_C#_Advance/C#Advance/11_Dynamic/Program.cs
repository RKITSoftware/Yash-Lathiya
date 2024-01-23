namespace _11_Dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dynamic avoids compile time checking

            dynamic d = 1;
            var testSum = d + 3;
            
            Console.WriteLine(testSum); // Here testSum is dynamic

            dynamic d1 = 7;
            dynamic d2 = "Mahendra Singh Dhoni";
            dynamic d3 = System.DateTime.Today;

            int i = d1;
            string str = d2;
            DateTime dt = d3;

            Console.WriteLine(i);
            Console.WriteLine(str);
            Console.WriteLine(dt);
        }
    }
}