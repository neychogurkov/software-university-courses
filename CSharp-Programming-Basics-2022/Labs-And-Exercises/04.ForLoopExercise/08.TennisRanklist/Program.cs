using System;

namespace _08.TennisRanklist
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
            double finalPoints = initialPoints + pointsWon;
            double averagePoints = pointsWon / tournaments;
            double percentageTournamentsWon = (double)tournamentsWon / tournaments*100;
            Console.WriteLine($"Final points: {Math.Floor(finalPoints)}");
            Console.WriteLine($"Average points: {Math.Floor(averagePoints)}");
            Console.WriteLine($"{percentageTournamentsWon:f2}%");
            
        }
    }
}
