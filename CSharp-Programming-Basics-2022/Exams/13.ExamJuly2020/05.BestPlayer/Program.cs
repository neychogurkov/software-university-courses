using System;

namespace _05.BestPlayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerName = Console.ReadLine();
            string bestPlayer = string.Empty;
            int bestPlayerGoals = int.MinValue;

            while (playerName!="END")
            {
                int goalsScored = int.Parse(Console.ReadLine());

                if (goalsScored > bestPlayerGoals)
                {
                    bestPlayerGoals = goalsScored;
                    bestPlayer = playerName;
                }

                if (goalsScored >= 10)
                {
                    break;
                }

                playerName = Console.ReadLine();
            }

            Console.WriteLine($"{bestPlayer} is the best player!");

            if (bestPlayerGoals >= 3)
            {
                Console.WriteLine($"He has scored {bestPlayerGoals} goals and made a hat-trick !!!");
            }
            else
            {
                Console.WriteLine($"He has scored {bestPlayerGoals} goals.");
            }
        }
    }
}
