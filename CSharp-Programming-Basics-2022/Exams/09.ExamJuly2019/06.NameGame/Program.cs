using System;

namespace _06.NameGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int winnerPoints = int.MinValue;
            string winnerName = string.Empty;

            while (name != "Stop")
            {
                int points = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    int number = int.Parse(Console.ReadLine());
                    if (name[i] == number)
                    {
                        points += 10;
                    }
                    else
                    {
                        points += 2;
                    }
                }

                if (winnerPoints <= points)
                {
                    winnerPoints = points;
                    winnerName = name;
                }

                name = Console.ReadLine();
            }

            Console.WriteLine($"The winner is {winnerName} with {winnerPoints} points!");
        }
    }
}
