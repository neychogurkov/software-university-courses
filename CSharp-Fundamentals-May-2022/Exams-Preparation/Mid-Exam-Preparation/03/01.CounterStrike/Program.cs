using System;

namespace _01.CounterStrike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int battlesWon = 0;
            int counter = 0;

            while (command!="End of battle")
            {
                counter++;
                int distance = int.Parse(command);

                if (energy - distance < 0)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {energy} energy");
                    return;
                }

                energy -= distance;
                battlesWon++;
                if (counter % 3 == 0)
                {
                    energy += battlesWon;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {battlesWon}. Energy left: {energy}");
        }
    }
}
