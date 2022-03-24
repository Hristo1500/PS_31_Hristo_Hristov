using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {

        public string FirstName;
        public string SecondName;
        public string LastName;
        public string FacultyName;
        public string Speciality;
        public string Degree;
        public string Status;
        public string FacultyNumber;
        public int Course;
        public int Flow;
        public int Group;
        public Student(string firstName, string secondName, string lastName, string faculty, string speciality,
            string degree, string status, string facultyNumber, int course, int flow, int group)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.LastName = lastName;
            this.FacultyName = faculty;
            this.Speciality = speciality;
            this.Degree = degree;
            this.Status = status;
            this.FacultyNumber = facultyNumber;
            this.Course = course;
            this.Flow = flow;
            this.Group = group;
        }
    }
}
