using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_Types_of_Class.Class.Sealed_Class
{
    /// <summary>
    /// Demonstration of sealed class
    /// </summary>
    public sealed class SealedClass
    {
        /// <summary>
        /// Method of this class, no method of sealed class can be changed.
        /// </summary>
        /// <returns> Random String </returns>
        public string ProtectedMethod()
        {
            return "I am protected method in sealed class, No one can manipulate me";
        }
    }
}