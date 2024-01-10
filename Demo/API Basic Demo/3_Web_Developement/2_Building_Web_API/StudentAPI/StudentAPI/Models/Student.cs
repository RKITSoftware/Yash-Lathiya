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
        public int Enrollment { get; set; }

        /// <summary>
        /// Name of Student
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of Department
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Graduation date of student
        /// </summary>
        public DateTime GraduationDate { get; set; }

        #endregion
    }
}