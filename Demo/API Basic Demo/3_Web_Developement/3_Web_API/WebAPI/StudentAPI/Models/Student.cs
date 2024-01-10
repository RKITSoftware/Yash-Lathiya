using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentAPI.Models
{
    public class Student
    {
        #region Public Methods

        /// <summary>
        /// Enrollment of Student
        /// </summary>
        public int u01f01 { get; set; }

        /// <summary>
        /// Name of Student
        /// </summary>
        public string u01f02 { get; set; }

        /// <summary>
        /// Name of Department
        /// </summary>
        public string u01f03 { get; set; }

        /// <summary>
        /// Graduation date of student
        /// </summary>
        public DateTime u01f04 { get; set; }

        #endregion
    }
}