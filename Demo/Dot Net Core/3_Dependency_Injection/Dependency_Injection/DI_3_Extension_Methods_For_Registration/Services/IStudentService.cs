using DI_3_Extension_Methods_For_Registration.Models;

namespace DI_3_Extension_Methods_For_Registration.Services
{
    /// <summary>
    /// Interface for student service 
    /// </summary>
    public interface IStudentService
    {
        #region Abstract Methods 

        public List<Stu01> GetStudents();

        #endregion

    }
}
