using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_Types_of_Class.Class.Abstract_Class
{
    /// <summary>
    /// Implements abstract & non-abstract methods
    /// </summary>
    public abstract class AbstractClass
    {
        #region Abstract Methods

        /// <summary>
        /// Abstract method which will consist identity of the child's identity
        /// </summary>
        public abstract string Who();

        #endregion

        #region Non-Abstract Method

        /// <summary>
        /// Non abstract method which doesn't require overriding by child class
        /// Gives greetings to particular person by his/her name.
        /// </summary>
        /// <param name="name"> Name of the user </param>
        /// <returns> Namaste {name} </returns>
        public string Greetings(string name)
        {
            return "Namaste " + name;
        }

        #endregion

    }
}