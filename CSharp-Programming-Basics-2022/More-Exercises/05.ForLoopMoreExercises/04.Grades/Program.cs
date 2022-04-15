using System;

namespace _04.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            double poorGrades = 0;
            double badGrades = 0;
            double goodGrades = 0;
            double excellentGrades = 0;
            double gradeSum = 0;

            for (int i = 0; i < students; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                gradeSum += grade;

                if (grade >= 2 && grade < 3)
                {
                    poorGrades++;
                }
                else if (grade >= 3 && grade < 4)
                {
                    badGrades++;
                }
                else if (grade >= 4 && grade < 5)
                {
                    goodGrades++;
                }
                else if (grade >= 5)
                {
                    excellentGrades++;
                }
            }

            Console.WriteLine($"Top students: {excellentGrades/students*100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {goodGrades/students*100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {badGrades/students*100:f2}%");
            Console.WriteLine($"Fail: {poorGrades/students*100:f2}%");
            Console.WriteLine($"Average: {gradeSum/students:f2}");
        }
    }
}
