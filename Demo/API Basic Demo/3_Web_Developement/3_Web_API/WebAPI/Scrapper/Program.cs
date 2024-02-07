namespace Scrapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Scrape scrape = new Scrape();
            scrape.ScrapWebPage("https://www.angelone.in/");
        }
    }
}