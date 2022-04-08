using System;

namespace _02.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int allowedPoorGrades = int.Parse(Console.ReadLine());
            int poorGradesCount = 0;
            double gradeSum = 0;
            int problemsCount = 0;
            string problemName = Console.ReadLine();
            string lastProblem = string.Empty;

            while (problemName != "Enough")
            {
                problemsCount++;
                int grade = int.Parse(Console.ReadLine());
                gradeSum += grade;
                if (grade <= 4)
                {
                    poorGradesCount++;
                }
                if (poorGradesCount == allowedPoorGrades)
                {
                    Console.WriteLine($"You need a break, {poorGradesCount} poor grades.");
                    return;
                }
                lastProblem = problemName;

                problemName = Console.ReadLine();
            }

            Console.WriteLine($"Average score: {gradeSum / problemsCount:f2}");
            Console.WriteLine($"Number of problems: {problemsCount}");
            Console.WriteLine($"Last problem: {lastProblem}");
        }
    }
}
