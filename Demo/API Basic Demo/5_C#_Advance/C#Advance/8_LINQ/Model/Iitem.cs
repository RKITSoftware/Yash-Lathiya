namespace _8_LINQ.Model
{
    /// <summary>
    /// Interface consisting commaon properties of mobile and laptop
    /// </summary>
    public interface Iitem
    {
        /// <summary>
        /// Price of Item
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Manufacturer Company of Item
        /// </summary>
        public string Company { get; set; }
    }
}
