using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1_Types_of_Class.Class.Partial_Class
{
    /// <summary>
    /// Implements all method relates to Identification
    /// Partial Class of the student
    /// </summary>
    public partial class Student
    {
        #region Public Methods

        /// <summary>
        /// ID of the Student
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the student
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address of the student
        /// </summary>
        public string Address { get; set; }

        #endregion

    }
}