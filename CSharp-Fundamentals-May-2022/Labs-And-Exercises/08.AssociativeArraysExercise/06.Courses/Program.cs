using System;
using System.Collections.Generic;

namespace _06.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string[] courseInfo = Console.ReadLine().Split(" : ");

                if (courseInfo[0] == "end")
                {
                    break;
                }

                string courseName = courseInfo[0];
                string studentName = courseInfo[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses[courseName] = new List<string>();
                }

                courses[courseName].Add(studentName);
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
