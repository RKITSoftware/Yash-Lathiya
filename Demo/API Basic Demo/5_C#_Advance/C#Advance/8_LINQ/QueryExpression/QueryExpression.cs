using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_LINQ.QueryExpression
{
    /// <summary>
    /// Explains LINQ Query Expression
    /// </summary>
    static class QueryExpression
    {
        public static void QueryExpressionLINQ()
        {
            // Specify the data source.
            int[] scores = { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
            foreach (var i in scoreQuery)
            {
                Console.Write(i + " ");
            }
        }
    }
}
