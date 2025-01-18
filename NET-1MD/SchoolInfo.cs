using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static NET_1MD.Person;

namespace NET_1MD
{
    //7 UZD
    [XmlRoot("SchoolInfo")]
    public class SchoolInfo //nomainīju īpašības uz public, lai tas būtu redzams schoolManager
    {
        public List<Student> Students { get; set; } //VS visu šo automātiski piedāvāja
        [XmlArray("Teachers")]
        [XmlArrayItem("Teacher")]
        public List<Teacher> Teachers { get; set; }
        [XmlArray("Courses")]
        [XmlArrayItem("Course")]
        public List<Course> Courses { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<Submission> Submissions { get; set; }

        public SchoolInfo() // izmantoju https://www.youtube.com/watch?v=aLhAmimoQj8&list=TLPQMDcxMDIwMjS9_9GISlYk1w&index=3 
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
            Courses = new List<Course>();
            Assignments = new List<Assignment>();
            Submissions = new List<Submission>();

            Students.Add(new Student("John", "Doe", GenderType.Man, "jd82218"));  //0
            Students.Add(new Student("Davis", "Dickinson", GenderType.Man, "dd99623")); //1
            Students.Add(new Student("Diana", "Myrtle", GenderType.Woman, "dm041278")); //2
            Students.Add(new Student("Luke", "Skywalker", GenderType.Man, "dm041278")); //3
            Students.Add(new Student("Elizabeth", "Hartley", GenderType.Woman, "dm041278")); //4
            Students.Add(new Student("James", "Holland", GenderType.Man, "dm041278")); //5
            Students.Add(new Student("Martha", "Jenkins", GenderType.Woman, "dm041278")); //6

            Teachers.Add(new Teacher("Josie", "Doe", GenderType.Woman, new DateTime(2004, 5, 15)));
            Teachers.Add(new Teacher("Neville", "Longbottom", GenderType.Man, new DateTime(2004, 5, 15)));
            Teachers.Add(new Teacher("Kristopher", "Ray", GenderType.Man, new DateTime(2004, 5, 15)));

            Courses.Add(new Course("Abstract Algebra", Teachers[0]));
            Courses.Add(new Course("Programming in Python", Teachers[1]));
            Courses.Add(new Course("Calculus", Teachers[2]));

            Assignments.Add(new Assignment(new DateTime(2024, 6, 7), Courses[0], "Calculate the determinant of the given matrices."));
            Assignments.Add(new Assignment(new DateTime(2024, 5, 15), Courses[1], "Make a program that parses through the given list."));
            Assignments.Add(new Assignment(new DateTime(2024, 6, 20), Courses[2], "Find the integral of the given functions."));

            Submissions.Add(new Submission(Assignments[0], Students[0], DateTime.Now, 9)); //jā, visi studenti iesūtīja assignment vienā laikā, kas par to?
            Submissions.Add(new Submission(Assignments[1], Students[0], DateTime.Now, 6));
            Submissions.Add(new Submission(Assignments[2], Students[0], DateTime.Now, 8));

            Submissions.Add(new Submission(Assignments[0], Students[1], DateTime.Now, 10));
            Submissions.Add(new Submission(Assignments[1], Students[1], DateTime.Now, 9));
            Submissions.Add(new Submission(Assignments[2], Students[1], DateTime.Now, 9));

            Submissions.Add(new Submission(Assignments[0], Students[2], DateTime.Now, 7));
            Submissions.Add(new Submission(Assignments[1], Students[2], DateTime.Now, 5));
            Submissions.Add(new Submission(Assignments[2], Students[2], DateTime.Now, 4));

            Submissions.Add(new Submission(Assignments[0], Students[3], DateTime.Now, 6));
            Submissions.Add(new Submission(Assignments[1], Students[3], DateTime.Now, 4));
            Submissions.Add(new Submission(Assignments[2], Students[3], DateTime.Now, 5));

            Submissions.Add(new Submission(Assignments[0], Students[4], DateTime.Now, 10));
            Submissions.Add(new Submission(Assignments[1], Students[4], DateTime.Now, 5));
            Submissions.Add(new Submission(Assignments[2], Students[4], DateTime.Now, 5));

            Submissions.Add(new Submission(Assignments[0], Students[5], DateTime.Now, 8));
            Submissions.Add(new Submission(Assignments[1], Students[5], DateTime.Now, 8));
            Submissions.Add(new Submission(Assignments[2], Students[5], DateTime.Now, 8));

            Submissions.Add(new Submission(Assignments[0], Students[6], DateTime.Now, 7));
            Submissions.Add(new Submission(Assignments[1], Students[6], DateTime.Now, 6));
            Submissions.Add(new Submission(Assignments[2], Students[6], DateTime.Now, 5));

        }

        //metodes, kas skaita īpašības, jo kāpēc ne?
        public int countAllTeachers() { return Teachers.Count; }
        public int countAllStudents() { return Students.Count; }
        public int countAllCourses() { return Courses.Count; }
        public int countAllAssignments() { return Assignments.Count; }
        public int countAllSubmissions() { return Submissions.Count; }
        //public void printAllStudents()
        //{
        //    Console.WriteLine("Students: ");
        //    foreach (Student student in Students)
        //    {
        //        Console.WriteLine(student.ToString());
        //    }
        //}
        //public void printAllTeachers()
        //{
        //    Console.WriteLine("Teachers: ");
        //    foreach (Teacher teacher in Teachers)
        //    {
        //        Console.WriteLine(teacher.ToString());
        //    }
        //}
        //public void printAllCourses()
        //{
        //    Console.WriteLine("Courses: ");
        //    foreach (Course course in Courses)
        //    {
        //        Console.WriteLine(course.ToString());
        //    }
        //}
        //public void printAllAssignments()
        //{
        //    Console.WriteLine("Assignments: ");
        //    foreach (Assignment assignment in Assignments)
        //    {
        //        Console.WriteLine($"{assignment.ToString()}");
        //    }
        //}
        //public void printAllSubmissions()
        //{
        //    Console.WriteLine("Submissions: ");
        //    foreach (Submission submission in Submissions)
        //    {
        //        Console.WriteLine(submission.ToString());
        //    }
        //}

        public string printAllStudents() //parveidoju metodes, lai taas atgrieztu string un neprintetu konsolee (VS so visu automatiski piedavaja)
        {
            string result = "Students: \n";
            foreach (Student student in Students)
            {
                result += student.ToString() + "\n";
            }
            return result;
        }
        public string printAllTeachers()
        {
            string result = "Teachers: \n";
            foreach (Teacher teacher in Teachers)
            {
                result += teacher.ToString() + "\n";
            }
            return result;
        }
        public string printAllCourses()
        {
            string result = "Courses: \n";
            foreach (Course course in Courses)
            {
                result += course.ToString() + "\n";
            }
            return result;
        }
        public string printAllAssignments()
        {
            string result = "Assignments: \n";
            foreach (Assignment assignment in Assignments)
            {
                result += $"{assignment.ToString()}" + "\n";
            }
            return result;
        }
        public string printAllSubmissions()
        {
            string result = "Submissions: \n";
            foreach (Submission submission in Submissions)
            {
                result += submission.ToString() + "\n";
            }
            return result;

        }
    }
}
