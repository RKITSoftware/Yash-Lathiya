using ExpenseTracker.Models;
using ExpenseTracker.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace ExpenseTracker.BL
{
    /// <summary>
    /// Consist Buisness Logic of all methods related to Expense
    /// </summary>
    public static class ExpenseManager
    {
        // To use Employee Service 
        private static ExpenseService objEmployeeService;
        // To assign dbFactory
        static ExpenseManager()
        {
            objEmployeeService = new ExpenseService(MyAppDbConnectionFactory.Instance);
        }
        public static void AddExpense( Exp01 objExp01)
        {
            objEmployeeService.AddExpense(objExp01); 
        }

        public static List<Exp01> GetExpense(int p01f02, DateTime p01f04)
        {
            return objEmployeeService.GetExpense(p01f02, p01f04);
        }

        public static List<Exp01> GetAllExpense(int p01f02)
        {
            return objEmployeeService.GetAllExpense(p01f02);
        }

        public static void UpdateExpense(Exp01 exp01)
        {
            objEmployeeService.UpdateExpense(exp01);
        }

        public static void DeleteExpense(int p01f01)
        {
            objEmployeeService.DeleteExpense(p01f01);
        }
    }
}