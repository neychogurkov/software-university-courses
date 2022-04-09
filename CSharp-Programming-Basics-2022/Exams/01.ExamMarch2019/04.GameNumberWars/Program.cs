using System;

namespace _04.GameNumberWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstPlayer = Console.ReadLine();
            string secondPlayer = Console.ReadLine();
            string command = Console.ReadLine();
            int pointsFirstPlayer = 0;
            int pointsSecondPlayer = 0;

            while (command!="End of game")
            {
                int cardFirstPlayer = int.Parse(command);
                int cardSecondPlayer = int.Parse(Console.ReadLine());

                if (cardFirstPlayer > cardSecondPlayer)
                {
                    pointsFirstPlayer += cardFirstPlayer - cardSecondPlayer;
                }
                else if (cardFirstPlayer < cardSecondPlayer)
                {
                    pointsSecondPlayer += cardSecondPlayer - cardFirstPlayer;
                }
                else
                {
                    Console.WriteLine("Number wars!");
                    string winner = firstPlayer;
                    cardFirstPlayer = int.Parse(Console.ReadLine());
                    cardSecondPlayer = int.Parse(Console.ReadLine());
                    if (cardFirstPlayer > cardSecondPlayer)
                    {
                        Console.WriteLine($"{firstPlayer} is winner with {pointsFirstPlayer} points");
                    }
                    else
                    {
                        Console.WriteLine($"{secondPlayer} is winner with {pointsSecondPlayer} points");
                    }
                    return;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{firstPlayer} has {pointsFirstPlayer} points");
            Console.WriteLine($"{secondPlayer} has {pointsSecondPlayer} points");
        }
    }
}
