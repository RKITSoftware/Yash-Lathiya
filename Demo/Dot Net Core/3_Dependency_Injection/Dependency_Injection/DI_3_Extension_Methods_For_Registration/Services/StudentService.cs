using DI_3_Extension_Methods_For_Registration.Models;

namespace DI_3_Extension_Methods_For_Registration.Services
{
    /// <summary>
    /// Implementations of student servie inteface 
    /// </summary>
    public class StudentService : IStudentService
    {
        #region Private Members

        private List<Stu01> lstStu01;

        #endregion

        #region Public Members

        /// <summary>
        /// Add students in list
        /// </summary>
        public StudentService() 
        { 
            lstStu01 = new List<Stu01>();
            lstStu01.Add(new Stu01() { u01f01 = 1001, u02f01 = "Sachin Tendulkar"});
            lstStu01.Add(new Stu01() { u01f01 = 1002, u02f01 = "Mahendra Singh Dhoni" });
        }

        /// <summary>
        /// Get all students from list
        /// </summary>
        /// <returns> list of all student </returns>
        public List<Stu01> GetStudents()
        {
            return lstStu01;
        }

        #endregion
    }
}
