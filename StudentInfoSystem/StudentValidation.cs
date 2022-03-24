using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;
namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student GetStudentDataByUser(User user)
        {
            StudentData studentData = new StudentData();
            if (String.IsNullOrWhiteSpace(user.FacNumber) || user == null)
            {
                Console.WriteLine("Empty facutly number or a student with that faculty number does not exist in the system.");
                return null;
            }
            IEnumerable<Student> students = studentData.getStudents();

            foreach (Student student in students)
            {
                if (student.FacultyNumber.Equals(user.FacNumber))
                {
                    return student;
                }
            }
            Console.WriteLine("No such student exists.");
            return null;
        }
    }
}
