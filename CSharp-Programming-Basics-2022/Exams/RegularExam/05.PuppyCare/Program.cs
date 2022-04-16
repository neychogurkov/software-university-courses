using System;

namespace _05.PuppyCare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodBought = int.Parse(Console.ReadLine()) * 1000;
            string command = Console.ReadLine();
            int totalFoodEaten = 0;

            while (command != "Adopted")
            {
                int food = int.Parse(command);
                totalFoodEaten += food;

                command = Console.ReadLine();
            }
            int diff = Math.Abs(totalFoodEaten - foodBought);

            if (foodBought >= totalFoodEaten)
            {
                Console.WriteLine($"Food is enough! Leftovers: {diff} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {diff} grams more.");
            }

        }
    }
}
