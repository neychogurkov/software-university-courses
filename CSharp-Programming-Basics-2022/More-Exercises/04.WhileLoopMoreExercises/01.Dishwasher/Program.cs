using System;

namespace _01.Dishwasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int detergentQuantity = int.Parse(Console.ReadLine()) * 750;
            string command = Console.ReadLine();
            int counter = 0;
            int cleanDishes = 0;
            int cleanPots = 0;

            while (command != "End")
            {
                int dishes = int.Parse(command);
                counter++;

                if (counter % 3 == 0)
                {
                    detergentQuantity -= 15 * dishes;
                    cleanPots += dishes;
                }
                else
                {
                    detergentQuantity -= 5 * dishes;
                    cleanDishes += dishes;
                }

                if (detergentQuantity < 0)
                {
                    Console.WriteLine($"Not enough detergent, {Math.Abs(detergentQuantity)} ml. more necessary!");
                    return;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Detergent was enough!");
            Console.WriteLine($"{cleanDishes} dishes and {cleanPots} pots were washed.");
            Console.WriteLine($"Leftover detergent {detergentQuantity} ml.");
        }
    }
}
