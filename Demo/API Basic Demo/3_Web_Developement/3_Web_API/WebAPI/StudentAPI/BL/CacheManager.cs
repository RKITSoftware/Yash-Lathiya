using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAPI.BL
{
    /// <summary>
    /// Implements logic of methods which are presented in CL Cache Controller
    /// </summary>
    public static class CacheManager
    {
        /// <summary>
        /// Creates dictionary of products consisting productName & ProductPrice
        /// </summary>
        /// <returns> Product Dictionary </returns>
        public static Dictionary<string,int> GetProducts()
        {
            // Cart consists data of itemname and price
            Dictionary<string, int> cart = new Dictionary<string, int>();

            cart.Add("item1", 12000);
            cart.Add("item2", 14000);
            cart.Add("item3", 16000);
            cart.Add("item4", 18000);
            cart.Add("item5", 22000);
            cart.Add("item6", 24000);

            return cart;
        } 
    }
}