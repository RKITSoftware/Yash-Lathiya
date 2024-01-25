using _7_Extension_Methods.Model;

namespace _7_Extension_Methods
{
    /// <summary>
    /// Demo of Extension Methods
    /// </summary>
    class Program
    {
        #region Public Methods

        static void Main(string[] args)
        {
            // List of Mob01 model is created & Inserted data

            List<Mob01> lstMob01 = new List<Mob01>();
            lstMob01.Add(new Mob01() { b01fo1 = 2001, b01fo2 = "Narzo10 Pro", b01f03 = "Realme", b01fo4 = 2, b01f05 = 19999 });
            lstMob01.Add(new Mob01() { b01fo1 = 2002, b01fo2 = "i Phone 13 Pro + ", b01f03 = "Apple", b01fo4 = 3, b01f05 = 121999 });

            // I want to add extension method which gives me Total price of all mobiles
            // I want to use lstMob01.TotalPrice()

            int totalPrice = lstMob01.ToatalPrice();

            Console.WriteLine(totalPrice);

            // I want to add extension method which gives list of Costly Mobiles
            // I want to use lstMob01.CostlyMobiles()

            var costlyMobiles = lstMob01.CostlyMobiles();

            foreach(Mob01 objMob01 in costlyMobiles)
            {
                Console.WriteLine(objMob01.b01fo2 + " " + objMob01.b01f05);
            }

            // I want to check how many mobiles of specific company
            // I want to use lstMob01.Count({ComanyName})

            //How many mobiles of apple company
            Console.WriteLine(lstMob01.Count("apple"));
        }

        #endregion
    }
}