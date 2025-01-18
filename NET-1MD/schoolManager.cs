﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NET_1MD
{
    public class schoolManager : IDataManager
    {
        private SchoolInfo _schoolinfo;

        public schoolManager(SchoolInfo schoolinfo)
        {
            _schoolinfo = schoolinfo;
        }
        //public void print()
        //{
        //    _schoolinfo.printAllStudents();
        //    _schoolinfo.printAllTeachers();
        //    _schoolinfo.countAllCourses();
        //    _schoolinfo.printAllAssignments();
        //    _schoolinfo.printAllSubmissions();

        //}

        public string print() //bisk izmainiju (VS automatiski piedavaja)
        {
            string result = _schoolinfo.printAllStudents();
            result += _schoolinfo.printAllTeachers();
            result += $"Courses: {_schoolinfo.countAllCourses()}\n";
            result += _schoolinfo.printAllAssignments();
            result += _schoolinfo.printAllSubmissions();
            return result;
        }
        //public void save() //draugs ieteica izmantot XML
        //{
        //    try
        //    {
        //        XmlSerializer serializer = new XmlSerializer(typeof(SchoolInfo));
        //        using (TextWriter writer = new StreamWriter("schooldata.xml"))
        //        {
        //            serializer.Serialize(writer, _schoolinfo);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error saving data: {ex.Message}");
        //    }
        //}

        public void save(string filePath = @"C:\Temp\schooldata.xml")
        {
            try
            {
                //string filePath = @"C:\Temp\schooldata.xml";

                string directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(SchoolInfo));
                using (TextWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, _schoolinfo);
                }

                Console.WriteLine($"Data saved successfully to {filePath}");

                // Verify the file exists and contains data
                if (File.Exists(filePath))
                {
                    string fileContent = File.ReadAllText(filePath);
                    if (!string.IsNullOrEmpty(fileContent))
                    {
                        Console.WriteLine("Data saved successfully and file verified.");
                    }
                    else
                    {
                        Console.WriteLine("Data saved but file appears to be empty.");
                    }
                }
                else
                {
                    Console.WriteLine("File not found after save attempt.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }
        public void load(string filePath = @"C:\Temp\schooldata.xml")
        {
            try
            {
                //string filePath = @"C:\Temp\schooldata.xml";
                if (File.Exists(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SchoolInfo));
                    using (TextReader reader = new StreamReader(filePath))
                    {
                        _schoolinfo = (SchoolInfo)serializer.Deserialize(reader);
                    }
                    Console.WriteLine($"Data loaded successfully from {filePath}");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }
        public void createTestData()
        {
            _schoolinfo = new SchoolInfo();

        }
        public void reset()
        {
            _schoolinfo.Students.Clear();
            _schoolinfo.Teachers.Clear();
            _schoolinfo.Courses.Clear();
            _schoolinfo.Assignments.Clear();
            _schoolinfo.Submissions.Clear();
        }

        public void addStudent(string name, string surname, Person.GenderType gender, string studentIDNumber) //jauna metode, kas lauj lietotajam pievienot jaunu studentu schoolInfo
        {
            _schoolinfo.Students.Add(new Student(name, surname, gender, studentIDNumber));
        }

        public List<Student> getStudents() //man nestradaja _schoolinfo var jo private
        {
            return _schoolinfo.Students;
        }
        public void addAssignment(DateTime deadline, Course course, string description) //jauna metode, kas lauj lietotajam pievienot jaunu Assignment schoolInfo
        {
            _schoolinfo.Assignments.Add(new Assignment(deadline, course, description));
            //_schoolinfo.Assignments.ToString();
        }
        public void addSubmission(Assignment assignment, Student student, DateTime submissionDate, int score) //jauna metode, kas lauj lietotajam pievienot jaunu Submission schoolInfo
        {
            _schoolinfo.Submissions.Add(new Submission(assignment, student, submissionDate, score));
        }

        public void editAssignment(Assignment assignment, DateTime deadline, Course course, string description) //jauna metode, kas lauj lietotajam rediget Assignment schoolInfo
        {
            assignment.Deadline = deadline;
            assignment.Course = course;
            assignment.Description = description;
        }
    }
}
