using ServiceStack.Data;

namespace ExpenseTracker.ORM
{

    /// <summary>
    /// Set up for database connection
    /// </summary>
    public static class MyAppDbConnectionFactory
    {
        // Instance of DbFactory
        public static IDbConnectionFactory Instance { get; set; }
    }
}