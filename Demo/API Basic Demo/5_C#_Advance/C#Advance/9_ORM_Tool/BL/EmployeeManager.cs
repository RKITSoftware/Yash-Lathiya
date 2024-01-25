using _9_ORM_Tool.Connection;
using _9_ORM_Tool.Models;

namespace _9_ORM_Tool.BL
{
    /// <summary>
    /// Consisting buisness logic of all methiods in Employee controller
    /// </summary>
    public static class EmployeeManager
    {
        #region Connect to dbFactory

        // To use Employee Service 
        private static EmployeeService objEmployeeService;
        // To assign dbFactory
        static EmployeeManager()
        {
            objEmployeeService = new EmployeeService(MyAppDbConnectionFactory.Instance);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds Employee details in Employee Table in database
        /// </summary>
        /// <returns></returns>
        public static void AddEmployee(Emp01 objEmp01)
        {
           objEmployeeService.AddEmployee(objEmp01);
        }

        /// <summary>
        /// To get employee details by employee id 
        /// </summary>
        /// <param name="p01f01"></param>
        /// <returns> Object of EMp01 class </returns>
        public static Emp01 GetEmployee(int p01f01)
        {
            return  objEmployeeService.GetEmployeeById(p01f01); ;
        }

        /// <summary>
        /// To update employee in database
        /// </summary>
        /// <param name="objEmp01"> New details of employee </param>
        public static void UpdateEmployee(Emp01 objEmp01)
        {
            objEmployeeService.UpdateEmployee(objEmp01);
        }

        /// <summary>
        /// To delete employee drom the database
        /// </summary>
        /// <param name="p01f01"> EMployee Id </param>
        public static void DeleteEmployee(int p01f01)
        {
            objEmployeeService.DeleteEmployee(p01f01);
        }

        #endregion
    }
}