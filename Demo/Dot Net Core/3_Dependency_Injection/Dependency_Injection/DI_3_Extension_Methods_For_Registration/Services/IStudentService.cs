using DI_3_Extension_Methods_For_Registration.Models;

namespace DI_3_Extension_Methods_For_Registration.Services
{
    /// <summary>
    /// Interface for student service 
    /// </summary>
    public interface IStudentService
    {
        #region Public Methods 

        /// <summary>
        /// Method which returns List of students 
        /// </summary>
        /// <returns> list of students </returns>
        public List<Stu01> GetStudents();

        #endregion

    }
}
