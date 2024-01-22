using ServiceStack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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