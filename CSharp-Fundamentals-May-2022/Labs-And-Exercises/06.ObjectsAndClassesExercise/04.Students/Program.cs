using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentInfo = Console.ReadLine().Split();
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                double grade = double.Parse(studentInfo[2]);

                Student student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

            foreach (var student in students.OrderByDescending(s=>s.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
    }
}
