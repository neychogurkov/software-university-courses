using System;

namespace _04.Darts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string player = Console.ReadLine();
            int pointsLeft = 301;
            string command = Console.ReadLine();
            int successfulShots = 0;
            int unsuccessfulShots = 0;

            while (command != "Retire")
            {
                int points = int.Parse(Console.ReadLine());
                if (command == "Double")
                {
                    points *= 2;
                }
                else if (command == "Triple")
                {
                    points *= 3;
                }

                if (points > pointsLeft)
                {
                    unsuccessfulShots++;
                }
                else
                {
                    successfulShots++;
                    pointsLeft -= points;
                }

                if (pointsLeft == 0)
                {
                    Console.WriteLine($"{player} won the leg with {successfulShots} shots.");
                    return;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{player} retired after {unsuccessfulShots} unsuccessful shots.");
        }
    }
}
