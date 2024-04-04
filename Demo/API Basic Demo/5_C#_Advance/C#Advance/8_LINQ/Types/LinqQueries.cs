using _8_LINQ.Model;

namespace _8_LINQ.Types
{
    /// <summary>
    /// Linq Queries
    /// </summary>
    internal class LinqQueries
    {
        /// <summary>
        /// Demonstrates execution of queries 
        /// </summary>
        public void ExecuteQueries()
        {
            // Adding Sample data
            var students = new List<Stu01>
            {
                new Stu01 { u01f01 = 1001, u01f02 = "Sachin Tendulkar", u01f03 = 101 },
                new Stu01 { u01f01 = 1002, u01f02 = "Mahendra Singh Dhoni", u01f03 = 105 },
                new Stu01 { u01f01 = 1003, u01f02 = "Virat Kohli", u01f03 = 103 },
                new Stu01 { u01f01 = 1004, u01f02 = "Shubhaman Gill", u01f03 = 104 },
                new Stu01 { u01f01 = 1005, u01f02 = "ABD", u01f03 = 102 }
            };

            var courses = new List<Crs01>
            {
                new Crs01 { s01f01 = 101, s01f02 = "Computer Engineering" },
                new Crs01 { s01f01 = 102, s01f02 = "Electrical Engineering" },
                new Crs01 { s01f01 = 103, s01f02 = "Chemical Engineering"},
                new Crs01 { s01f01 = 104, s01f02 = "Civil Engineering" }
            };

            // Filtering
            // selects student whose name is start with "A"
            var filteredStudents = students.Where(s => s.u01f02.StartsWith("A"));

            Console.WriteLine("Filtered Students:");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student.u01f01 + "\t" + student.u01f02 + "\t" + student.u01f03);
            }
            Console.WriteLine("############################");

            // Projection
            // selects name of all students
            var studentNames = students.Select(s => s.u01f02);
            
            Console.WriteLine("Student Names:");
            foreach (var name in studentNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("############################");

            // Ordering
            // orders all student by their
            var orderedStudents = students.OrderBy(s => s.u01f03);
            Console.WriteLine("Ordered Students:");
            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student.u01f01 + "\t" + student.u01f02 + "\t" + student.u01f03);
            }
            Console.WriteLine();

            // Join
            // join by course id 
            var joinedData = students.Join(courses,
                                           student => student.u01f03,
                                           course => course.s01f01,
                                           (student, course) => new
                                           {
                                               Enrollment = student.u01f01,
                                               StudentName = student.u01f02,
                                               CourseName = course.s01f02
                                           });
            Console.WriteLine("Joined Data:");
            foreach (var data in joinedData)
            {
                Console.WriteLine(data);
            }
            Console.WriteLine("############################");

            // Group Join (Left Join)
            // Left join on Course Id 
            var leftJoinedData = students.GroupJoin( courses,
                                                     student => student.u01f03,
                                                     course => course.s01f01,
                                                     (student, courseGroup) => new
                                                     {
                                                         Name = student.u01f02,
                                                         Courses = courseGroup.DefaultIfEmpty(new Crs01 { s01f02 = "No Course" })
                                                     })
                                          .SelectMany(x => x.Courses.Select(course => new
                                          {
                                              x.Name,
                                              CourseName = course.s01f02
                                          }));
            
            Console.WriteLine("Left Joined Data:");
            foreach (var data in leftJoinedData)
            {
                Console.WriteLine(data);
            }
            Console.WriteLine("############################");

            // Set
            // Different Corse Id 
            var distinctStudentNames = students.Select(s => s.u01f03).Distinct();

            Console.WriteLine("Distinct Course Id:");
            foreach (var name in distinctStudentNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("############################");

            // Quantifier

            // all student enrollment greater than 1002
            var allStudentsHaveIds = students.All(s => s.u01f01 >= 1001);
            
            Console.WriteLine($"All students have ids: {allStudentsHaveIds}");

            Console.WriteLine("############################");

            // Aggregation
            var totalStudentCount = students.Count();
            var maxStudentId = students.Max(s => s.u01f01);
            var minStudentId = students.Min(s => s.u01f01);
            var sumOfStudentIds = students.Sum(s => s.u01f01);

            Console.WriteLine($"Total student count: {totalStudentCount}");
            Console.WriteLine($"Max student id: {maxStudentId}");
            Console.WriteLine($"Min student id: {minStudentId}");
            Console.WriteLine($"Sum of student ids: {sumOfStudentIds}");
        }
    }
}
