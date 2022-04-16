using System;

namespace _06.GoldMine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int locations = int.Parse(Console.ReadLine());

            for (int i = 0; i < locations; i++)
            {
                double estimatedAverageYield = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                double yieldSum = 0;

                for (int j = 0; j < days; j++)
                {
                    double dailyYield = double.Parse(Console.ReadLine());
                    yieldSum += dailyYield;
                }

                double averageYield = yieldSum / days;

                if (averageYield >= estimatedAverageYield)
                {
                    Console.WriteLine($"Good job! Average gold per day: {averageYield:f2}.");
                }
                else
                {
                    Console.WriteLine($"You need {estimatedAverageYield-averageYield:f2} gold.");
                }

            }
        }
    }
}
