using System;

namespace _05.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tournaments = int.Parse(Console.ReadLine());
            int initialPoints = int.Parse(Console.ReadLine());
            int pointsWon = 0;
            int tournamentsWon = 0;

            for (int i = 0; i < tournaments; i++)
            {
                string stage = Console.ReadLine();

                if (stage == "W")
                {
                    tournamentsWon++;
                    pointsWon += 2000;
                }
                else if (stage == "F")
                {
                    pointsWon += 1200;
                }
                else if (stage == "SF")
                {
                    pointsWon += 720;
                }
            }

            int finalPoints = initialPoints + pointsWon;
            double averagePoints = (double)pointsWon / tournaments;
            double winRate = (double)tournamentsWon / tournaments * 100;

            Console.WriteLine($"Final points: {finalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{winRate:f2}%");
        }
    }
}
