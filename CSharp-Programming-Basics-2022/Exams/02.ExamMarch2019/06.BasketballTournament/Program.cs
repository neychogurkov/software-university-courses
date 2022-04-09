using System;

namespace _06.BasketballTournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string tournamentName = Console.ReadLine();
            int gamesWon = 0;
            int gamesLost = 0;
            int gamesCount = 0;

            while(tournamentName!="End of tournaments")
            {
                int games = int.Parse(Console.ReadLine());

                for(int i = 1; i <= games; i++)
                {
                    gamesCount++;
                    int teamPoints = int.Parse(Console.ReadLine());
                    int opponentPoints = int.Parse(Console.ReadLine());

                    if (teamPoints > opponentPoints)
                    {
                        gamesWon++;
                        Console.WriteLine($"Game {i} of tournament {tournamentName}: win with {teamPoints-opponentPoints} points.");
                    }
                    else
                    {
                        gamesLost++;
                        Console.WriteLine($"Game {i} of tournament {tournamentName}: lost with {opponentPoints - teamPoints} points.");
                    }
                }

                tournamentName = Console.ReadLine();
            }

            double winPercentage = (double)gamesWon / gamesCount * 100;
            double lossPercentage = (double)gamesLost / gamesCount * 100;
            Console.WriteLine($"{winPercentage:f2}% matches win");
            Console.WriteLine($"{lossPercentage:f2}% matches lost");
        }
    }
}
