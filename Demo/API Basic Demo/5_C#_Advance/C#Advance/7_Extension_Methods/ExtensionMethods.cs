using _7_Extension_Methods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Extension_Methods
{
    /// <summary>
    /// Consist all Extension Methods
    /// </summary>
    static class ExtensionMethods
    {
        #region Public Methods 

        /// <summary>
        /// Add Extension Method to list of Mob01 class &
        /// Calculates Total price of all mobiles
        /// </summary>
        /// <param name="lstMob01"> List of Mobile ( Mob01 class ) </param>
        /// <returns> Total Price of All mobiles </returns>
        public static int ToatalPrice(this List<Mob01> lstMob01)
        {
            int totalPrice = 0;

            foreach (Mob01 objMob01 in lstMob01) 
            {
                totalPrice += objMob01.b01f05;
            }

            return totalPrice;
        }

        /// <summary>
        /// Gives list of all costly mobiles ,
        /// Copstly moniles are mobiles which has price greater than 100k 
        /// </summary>
        /// <param name="lstMob01"></param>
        /// <returns> List of Costly Mobiles </returns>
        public static List<Mob01> CostlyMobiles(this List<Mob01> lstMob01)
        {
            List<Mob01> lstMob01Costly = new List<Mob01>();

            foreach(Mob01 objMob01 in lstMob01)
            {
                if(objMob01.b01f05 > 100000)
                {
                    lstMob01Costly.Add(objMob01);
                }
            }

            return lstMob01Costly;
        }

        /// <summary>
        /// Calculates hw many mobiles are in list which is of a specific comapny
        /// </summary>
        /// <param name="lstMob01"> List of Mobile </param>
        /// <param name="companyName"></param>
        /// <returns> Count of mobiles which is of a company which passe in parameter</returns>
        public static int Count(this List<Mob01> lstMob01, string companyName)
        {
            int count = 0;

            foreach(Mob01 objMob01 in lstMob01)
            {
                if(objMob01.b01f03?.ToLower() == companyName.ToLower())
                {
                    count++;
                }
            }

            return count;
        }

        #endregion
    }
}
