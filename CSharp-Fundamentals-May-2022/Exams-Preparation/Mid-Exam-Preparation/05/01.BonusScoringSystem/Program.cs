using System;

namespace _01.BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            double maxBonusPoints = 0;
            int bestStudentAttendances = 0;

            for (int i = 0; i < numberOfStudents; i++)
            {
                int studentAttendances = int.Parse(Console.ReadLine());
                double totalBonus = (double)studentAttendances / lectures * (5 + additionalBonus);

                if (totalBonus > maxBonusPoints)
                {
                    maxBonusPoints = totalBonus;
                    bestStudentAttendances = studentAttendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Round(maxBonusPoints)}.");
            Console.WriteLine($"The student has attended {bestStudentAttendances} lectures.");
        }
    }
}
