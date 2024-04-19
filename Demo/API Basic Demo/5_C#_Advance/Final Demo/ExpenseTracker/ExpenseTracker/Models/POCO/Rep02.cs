using ServiceStack.DataAnnotations;
using System;

namespace ExpenseTracker.Models.POCO
{
    /// <summary>
    /// Class of Model - Report
    /// </summary>
    [Alias("Rep02")]
    public class Rep02
    {
        #region Public Members

        /// <summary>
        /// ReportId
        /// </summary>
        [PrimaryKey]
        public int P02f01 { get; set; }

        /// <summary>
        /// Report
        /// </summary>
        public string P02f02 { get; set; }

        /// <summary>
        /// Report Creation Time
        /// </summary>
        public DateTime P02f03 { get; set; } = DateTime.Now;

        #endregion
    }
}