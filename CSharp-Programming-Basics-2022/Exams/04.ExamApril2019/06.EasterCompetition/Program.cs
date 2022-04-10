using System;

namespace _06.EasterCompetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int easterBreads = int.Parse(Console.ReadLine());
            int maxPoints = int.MinValue;
            string winner = string.Empty;

            for (int i = 0; i < easterBreads; i++)
            {
                string baker = Console.ReadLine();
                int points = 0;

                while (true)
                {
                    string command = Console.ReadLine();

                    if (command == "Stop")
                    {
                        break;
                    }

                    int rating = int.Parse(command);
                    points += rating;
                }

                Console.WriteLine($"{baker} has {points} points.");
                if (maxPoints < points)
                {
                    Console.WriteLine($"{baker} is the new number 1!");
                    maxPoints = points;
                    winner = baker;
                }
            }

            Console.WriteLine($"{winner} won competition with {maxPoints} points!");
        }
    }
}
