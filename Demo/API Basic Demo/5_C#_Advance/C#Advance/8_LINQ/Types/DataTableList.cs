using _8_LINQ.Model;

namespace _8_LINQ.Types
{
    /// <summary>
    /// Performs operation on Data table with List 
    /// </summary>
    class DataTableList
    {
        #region Public Methods

        /// <summary>
        /// Apply Linq on list 
        /// </summary>
        public void QueryOnList()
        {
            // List of Mobile
            List<Mob01> lstMob01 = new List<Mob01> ();
            lstMob01.Add (new Mob01() { b01fo1 = 2001, b01fo2 = "Narzo10 Pro", Company = "Realme", b01fo4 = 2, Price = 19999 });
            lstMob01.Add (new Mob01() { b01fo1 = 2002, b01fo2 = "i Phone 13 Pro + ", Company = "Apple", b01fo4 = 3, Price = 121999 });

            // Query which finds mobile of price greater than 100000
            var query  = from mobile in lstMob01
                         where mobile.Price > 100000
                         select mobile;

            // Print Query

            foreach (Mob01 objMob01 in query)
            {
                Console.WriteLine($"Id : {objMob01.b01fo1}, Name : {objMob01.b01fo2}, Company : {objMob01.Company}, Sim-Card-Slots : {objMob01.b01fo4}, Price : {objMob01.Price}");
            }

        }

        #endregion
    }
}
