namespace _1_Types_of_Class.Class.Partial_Class
{
    /// <summary>
    /// Implements all educational detail of the student
    /// Partial Class of Student
    /// </summary>
    public partial class Student
    {
        #region Public Methods

        /// <summary>
        /// Provides university name of the student
        /// </summary>
        /// <returns> Gujarat Technological University </returns>
        public string GetUniversityName()
        {
            return "Gujarat Technological University";
        }

        /// <summary>
        /// Provides CGPA of the student
        /// </summary>
        /// <returns> 9.25 </returns>
        public double GetCgpa()
        {
            return 9.25;
        }

        #endregion
    }
}