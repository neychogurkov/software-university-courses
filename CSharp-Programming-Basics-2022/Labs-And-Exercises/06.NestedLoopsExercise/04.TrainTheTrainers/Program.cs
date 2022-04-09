using System;

namespace _04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();
            double totalAverageGrade = 0;
            double presentationsCount = 0;

            while (presentationName != "Finish")
            {
                double gradeSum = 0;
                presentationsCount++;

                for (int i = 0; i < n; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    gradeSum += grade;
                }

                double averageGrade = gradeSum / n;
                totalAverageGrade += averageGrade;

                Console.WriteLine($"{presentationName} - {averageGrade:f2}.");

                presentationName = Console.ReadLine();
            }

            Console.WriteLine($"Student's final assessment is {totalAverageGrade/presentationsCount:f2}.");
        }
    }
}
