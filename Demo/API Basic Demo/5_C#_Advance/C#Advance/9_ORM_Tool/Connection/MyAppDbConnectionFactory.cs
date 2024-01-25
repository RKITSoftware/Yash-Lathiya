using ServiceStack.Data;

namespace _9_ORM_Tool.Connection
{
    /// <summary>
    /// Set up for database connection
    /// </summary>
    public static class MyAppDbConnectionFactory
    {
        // Instance of DbFactory
        public static IDbConnectionFactory Instance {get; set;}
    }
}