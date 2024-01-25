using _8_LINQ.Model;
using System.Data;


namespace _8_LINQ.Types
{
    /// <summary>
    /// Performs operation on Data table with Linq 
    /// </summary>
    class DataTableLINQ
    {
        #region Public Methods 

        /// <summary>
        /// Creates Datatable & apply on query by using linq
        /// </summary>
        public void DataTableWithLinqQuery() 
        {
            //Create DataTable only

            System.Data.DataTable employee = new System.Data.DataTable("Employee");

            //Add Column into datatable

            employee.Columns.Add("EmployeeId", typeof(int));
            employee.Columns.Add("Name", typeof(string));
            employee.Columns.Add("Position", typeof(string));

            //Add rows into datatable

            employee.Rows.Add(1001, "Sachin Tendulkar", "Full Stack Developer");
            employee.Rows.Add(1002, "Virat Kohli", "Full Stack Developer");
            employee.Rows.Add(1003, "Mahendra Singh Dhoni", "Full Stack Developer");
            employee.Rows.Add(1004, "Sunil Gawaskar", "Full Stack Developer");

            //Add primary key into table

            employee.PrimaryKey = new DataColumn[] { employee.Columns["EmployeeId"] };

            // Linq Query
            // Select the employee which are having Employee Id greater than  1002

            var query = from emp in employee.AsEnumerable()
                        where emp.Field<int>("EmployeeId") > 1002
                        orderby emp.Field<int>("EmployeeId")
                        select emp;

            // Iterate employees get in query
            foreach (var emp in query)
            {
                Console.WriteLine();
                Console.WriteLine("Employee Id : " + emp["EmployeeId"] + ", Name : " + emp["Name"] + ", Position : " + emp["Position"]);
            }
        }

        /// <summary>
        /// Implements CopyToDataTable() method to create datatable from linq Query
        /// </summary>
        public void CopyToDataTableLinq()
        {
            // Items details are added in array
            var items = new Iitem[]
            {
                new Lap01{ p01fo1 = 1001, p01fo2 = "EQ2040AU", Company = "HP", p01fo4 = true, Price = 54999},
                new Lap01{ p01fo1 = 1002, p01fo2 = "AU4040AU", Company = "Acer", p01fo4 = false, Price = 49999 },
                new Mob01{ b01fo1 = 2001, b01fo2 = "Narzo10 Pro", Company = "Realme", b01fo4 = 2, Price = 19999},
                new Mob01{ b01fo1 = 2002, b01fo2 = "i Phone 13 Pro + ", Company = "Apple", b01fo4 = 3, Price = 121999}
            };

            // Query on items (Laptop & Mobile)
            // Find items which price is greater than 50000

            var query = from i in items
                        where i.Price > 50000
                        orderby i.Company
                        select new { i.Price, i.Company };

            // Create Data Table by query
            var costlyItems = CreateDataTable(query);

            // Print Data table 
            foreach(var item in costlyItems.AsEnumerable())
            {
                Console.WriteLine(item["Company"] + " " + item["Price"]);
            }

        }

        /// <summary>
        /// Logic of creating data table from the query 
        /// </summary>
        /// <param name="query"></param>
        /// <returns> Data table </returns>
        private DataTable CreateDataTable(IEnumerable<object> query)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Company", typeof(string));
            dt.Columns.Add("Price", typeof(int));

            foreach(var item in query)
            {
                // Add all properties in query 
                var propertyValues = new Dictionary<string, object>();

                // Extract property values using reflection
                foreach (var property in item.GetType().GetProperties())
                {
                    propertyValues.Add(property.Name, property.GetValue(item));
                }

                // Add row

                DataRow dr = dt.NewRow();
                dr["Company"] = propertyValues["Company"];
                dr["Price"] = propertyValues["Price"];

                dt.Rows.Add(dr);
            }

            return dt;
        }


        #endregion
    }
}
