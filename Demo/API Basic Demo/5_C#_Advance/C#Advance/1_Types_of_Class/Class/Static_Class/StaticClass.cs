namespace _1_Types_of_Class.Class.Static_Class
{
    /// <summary>
    /// Demonstrates Static class implementation
    /// </summary>
    public static class StaticClass
    {
        /// <summary>
        /// Static method -> each method in static class must be static method
        /// </summary>
        /// <param name="name"> Name of user </param>
        /// <returns> Greeting Message </returns>
        public static string Greetings(string name)
        {
            return "Namaste " + name ;
        }
    }
}