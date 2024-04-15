using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _12_Database_With_CRUD.Models
{
    /// <summary>
    /// Class of Model - Emp01
    /// </summary>
    [Alias("EMP01")]
    public class Emp01
    {
        #region Public Members

        /// <summary>
        /// Id of Emp01 
        /// </summary
        [PrimaryKey]
        public int P01f01 { get; set; }

        /// <summary>
        /// Name of Emp01
        /// </summary
        public string P01f02 { get; set; }

        /// <summary>
        /// Position of Emp01
        /// </summary
        public string P01f03 { get; set; }

        /// <summary>
        /// Annual Package of Emp01
        /// </summary
        public int P01f04 { get; set; }

        /// <summary>
        /// Created on
        /// </summary>
        [IgnoreOnUpdate]
        public DateTime P01f05 { get; set; }

        /// <summary>
        /// Updated on
        /// </summary>
        public DateTime P01f06 { get; set; }

        #endregion
    }
}