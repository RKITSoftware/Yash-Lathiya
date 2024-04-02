using DI_3_Extension_Methods_For_Registration.Models;

namespace DI_3_Extension_Methods_For_Registration.Services
{
    public class StudentService : IStudentService
    {
        private List<Stu01> lstStu01;

        public StudentService() 
        { 
            lstStu01 = new List<Stu01>();
            lstStu01.Add(new Stu01() { u01f01 = 1001, u02f01 = "Sachin Tendulkar"});
            lstStu01.Add(new Stu01() { u01f01 = 1002, u02f01 = "Mahendra Singh Dhoni" });
        }

        public List<Stu01> GetStudents()
        {
            return lstStu01;
        }
    }
}
