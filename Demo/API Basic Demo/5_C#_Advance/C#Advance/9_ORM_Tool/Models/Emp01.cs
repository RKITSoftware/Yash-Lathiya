using ServiceStack.DataAnnotations;

namespace _9_ORM_Tool.Models
{
    /// <summary>
    /// Employee
    /// </summary>
    [Alias("EMP01")]
    public class Emp01
    {
        #region Public Properties

        /// <summary>
        /// Id of Employee 
        /// </summary>
        public int p01f01 { get; set; }

        /// <summary>
        /// Name of Employee
        /// </summary>
        public string p01f02 { get; set; } 
        
        /// <summary>
        /// Position of EMployee
        /// </summary>
        public string p01f03 { get; set; }

        /// <summary>
        /// Annual Package of Employee
        /// </summary>
        public int p01f04 { get; set;}

        #endregion
    }
}