using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (command!="end")
            {
                string[] studentInfo = command.Split();
                string studentFirstName = studentInfo[0];
                string studentLastName = studentInfo[1];
                int studentAge = int.Parse(studentInfo[2]);
                string studentHomeTown = studentInfo[3];

                Student student = new Student(studentFirstName, studentLastName, studentAge, studentHomeTown);
                students.Add(student);

                command = Console.ReadLine();
            }

            string city = Console.ReadLine();

            foreach (var student in students.Where(s=>s.HomeTown==city))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }
    }
}
