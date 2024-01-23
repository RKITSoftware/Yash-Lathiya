using _8_LINQ.Types;

namespace _8_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Query Expression

            Console.WriteLine("*****************************************");
            Console.WriteLine("LINQ - Query Expression");
            Console.WriteLine("*****************************************");

            // Applied Query Expression of LINQ on array
            QueryExpression.QueryExpressionLINQ();

            #endregion

            #region LINQ & DataTable

            Console.WriteLine("*****************************************");
            Console.WriteLine("LINQ & DataTable");
            Console.WriteLine("*****************************************");

            // Applied LINQ query on DataTable
            DataTableLINQ dataTableLINQ = new DataTableLINQ();
            dataTableLINQ.DataTableWithLinqQuery();

            // Create Datatable by query
            dataTableLINQ.CopyToDataTableLinq();

            #endregion

            #region LINQ & List

            Console.WriteLine("*****************************************");
            Console.WriteLine("LINQ & List");
            Console.WriteLine("*****************************************");

            // Applied LINQ on list
            DataTableList dataTableList = new DataTableList();
            dataTableList.QueryOnList();

            #endregion
        }

    }
}