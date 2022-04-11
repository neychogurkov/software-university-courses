using System;

namespace _05.CareOfPuppy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodBought = int.Parse(Console.ReadLine())*1000;
            string command = Console.ReadLine();
            int totalFoodEaten = 0;

            while (command!="Adopted")
            {
                int foodEaten = int.Parse(command);
                totalFoodEaten += foodEaten;

                command = Console.ReadLine();
            }

            int diff = Math.Abs(foodBought - totalFoodEaten);
            if (totalFoodEaten <= foodBought)
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
