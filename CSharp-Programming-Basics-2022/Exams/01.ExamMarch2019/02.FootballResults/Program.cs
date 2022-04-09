using System;

namespace _02.FootballResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wins = 0;
            int losses = 0;
            int draws = 0;

            for (int i = 0; i < 3; i++)
            {
                string result = Console.ReadLine();
                int teamGoals = int.Parse(result[0].ToString());
                int opponentGoals = int.Parse(result[2].ToString());

                if (teamGoals > opponentGoals)
                {
                    wins++;
                }
                else if (teamGoals == opponentGoals)
                {
                    draws++;
                }
                else
                {
                    losses++;
                }
            }

            Console.WriteLine($"Team won {wins} games.");
            Console.WriteLine($"Team lost {losses} games.");
            Console.WriteLine($"Drawn games: {draws}");
        }
    }
}
