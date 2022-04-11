using System;

namespace _05.FootballTournament
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string clubName = Console.ReadLine();
            int gamesPlayed = int.Parse(Console.ReadLine());
            int wins = 0;
            int draws = 0;
            int losses = 0;
            int points = 0;

            if (gamesPlayed == 0)
            {
                Console.WriteLine($"{clubName} hasn't played any games during this season.");
                return;
            }

            for (int i = 0; i < gamesPlayed; i++)
            {
                char result = char.Parse(Console.ReadLine());

                switch (result)
                {
                    case 'W':
                        {
                            points += 3;
                            wins++;
                            break;
                        }
                    case 'D':
                        {
                            points += 1;
                            draws++;
                            break;
                        }
                    case 'L':
                        losses++;
                        break;
                }
            }

            Console.WriteLine($"{clubName} has won {points} points during this season.");
            Console.WriteLine("Total stats:");
            Console.WriteLine($"## W: {wins}");
            Console.WriteLine($"## D: {draws}");
            Console.WriteLine($"## L: {losses}");
            Console.WriteLine($"Win rate: {(double)wins/gamesPlayed*100:f2}%");
        }
    }
}
