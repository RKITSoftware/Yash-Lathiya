using System;
using System.Data;
class DataTable
{
    static void Main(string[] args)
    {
        //Create Dataset and add table into it

        DataSet dataSet = new DataSet();
        System.Data.DataTable students = dataSet.Tables.Add("students");

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

        //Modify data into dataTable

        //change 1st row's --> position of employee where employeeId is 1001

        DataRow firstRow = employee.Rows.Find(1001);
        firstRow["Position"] = "Product Manager";

        //Iterate table

        foreach (DataRow row in employee.Rows)
        {
            Console.WriteLine(row["EmployeeId"] + " " + row["Name"] + " " + row["Position"]);
        }
    }
}