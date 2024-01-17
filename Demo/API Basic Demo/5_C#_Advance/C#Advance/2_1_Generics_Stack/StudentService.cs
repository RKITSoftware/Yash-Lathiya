using _2_1_Generics_Stack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_1_Generics_Stack
{
    public class StudentService : IGenericService<Stu01>
    {
        Stack<Stu01> lstStudent = new Stack<Stu01>();
        /// <summary>
        ///  the student list with sample data.
        /// </summary>
        public StudentService()
        {
            for (int i = 1; i < 10; i++)
            {
                lstStudent.Push(new Stu01()
                {
                    u01f01 = i,
                    u01f02 = "Stu" + i,
                    u01f03 = "100" + i
                });
            }
        }
        /// <summary>
        /// Deletes a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to be deleted.</param>
        /// <returns>A list of students after the deletion operation.</returns>
        public Stack<Stu01> Delete(int id)
        {
            // Create a new stack excluding the element to be deleted
            Stack<Stu01> newStack = new Stack<Stu01>(lstStudent.Where(x => x.u01f01 != id));
            lstStudent = newStack;
            return newStack;
        }
        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>A list of all students.</returns>
        public Stack<Stu01> GetAll()
        {
            return lstStudent;
        }
        /// <summary>
        /// Gets a student by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the student to be retrieved.</param>
        /// <returns>The student with the specified identifier.</returns>
        public Stu01 GetById(int id)
        {
            return lstStudent.Where(x => x.u01f01 == id).FirstOrDefault();
        }
        /// <summary>
        /// Inserts a new student.
        /// </summary>
        /// <param name="entity">The student to be inserted.</param>
        /// <returns>A list of students after the insertion operation.</returns>

        public Stack<Stu01> Insert(Stu01 entity)
        {
            lstStudent.Push(entity);
            return lstStudent;
        }

      
    }
}