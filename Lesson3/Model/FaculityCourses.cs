using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3.Model
{
    internal class FaculityCourses
    {
        public string Name { get;}
        public List<Course> Courses { get;}
        public FaculityCourses(string name, List<Course> courses)
        {
            Name = name;
            Courses = courses;                       
        }
        private static List<Course> courses1= new List<Course>()
            { 
                new Course("f1course1",1), 
                new Course("f1course2",11), 
                new Course("f1course3",21), 
                new Course("f1course4",31)
            };
        private static List<Course> courses2 = new List<Course>()
            {
                new Course("f2course1",2),
                new Course("f2course2",12),
                new Course("f2course3",22),
                new Course("f2course4",32)
            };
        private static List<Course> courses3 = new List<Course>()
            {
                new Course("f3course1",3),
                new Course("f3course2",13),
                new Course("f3course3",23),
                new Course("f3course4",33)
            };
        private static List<FaculityCourses>  facultyCourses = new List<FaculityCourses>()
            {
                new FaculityCourses("Faculty1", courses1),
                new FaculityCourses("Faculty2", courses2),
                new FaculityCourses("Faculty3", courses3)
            };
        public static List<string> GetFaculty()
        {
            return facultyCourses
                .Select(fc => fc.Name)
                .ToList();
        }

        public static List<Course> GetCourses(int facultySelected)
        {
            if (facultySelected == -1)
                return null; // сомнительное решение
            return facultyCourses[facultySelected].Courses;
        }
        public static List<Course> GetCourses()
        {
            return null;
        }
    }
}
