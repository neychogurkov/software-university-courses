using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentsGrades = new Dictionary<string, List<double>>();

            int studentsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentsCount; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentsGrades.ContainsKey(studentName))
                {
                    studentsGrades[studentName] = new List<double>();
                }

                studentsGrades[studentName].Add(grade);
            }

            studentsGrades = studentsGrades
                .Where(s => s.Value.Average() >= 4.50)
                .ToDictionary(s => s.Key, s => s.Value);

            foreach (var student in studentsGrades)
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}
