using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            int gradesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < gradesCount; i++)
            {
                string[] gradeInfo = Console.ReadLine().Split();

                AddGrade(studentsGrades, gradeInfo);
            }

            PrintGrades(studentsGrades);
        }

        static void AddGrade(Dictionary<string, List<decimal>> studentsGrades, string[] gradeInfo)
        {
            string studentName = gradeInfo[0];
            decimal grade = decimal.Parse(gradeInfo[1]);

            if (!studentsGrades.ContainsKey(studentName))
            {
                studentsGrades[studentName] = new List<decimal>();
            }

            studentsGrades[studentName].Add(grade);
        }

        static void PrintGrades(Dictionary<string, List<decimal>> studentsGrades)
        {
            foreach (var (studentName, grades) in studentsGrades)
            {
                Console.WriteLine($"{studentName} -> {string.Join(" ", grades.Select(g => g.ToString("F2")))} (avg: {grades.Average():f2})");
            }
        }
    }
}
