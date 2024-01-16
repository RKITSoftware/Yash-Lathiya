using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_Types_of_Class.Class.Abstract_Class
{
    /// <summary>
    /// Demonstrates Child Class
    /// </summary>
    public class ChildClass : AbstractClass
    {
        #region Overriden Methods

        /// <summary>
        /// Overriden the abstract method of base class
        /// </summary>
        /// <returns> Identity in string format </returns>
        public override string Who()
        {
            return "Im child class, I've inherited this method from abstract class";
        }

        #endregion
    }
}