using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeineMilligrams = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            int caffeineTaken = 0;

            while (caffeineMilligrams.Any() && energyDrinks.Any())
            {
                int currentCaffeineMiligrams = caffeineMilligrams.Pop();
                int currentEnergyDrink = energyDrinks.Dequeue();
                int currentCaffeine = currentCaffeineMiligrams * currentEnergyDrink;

                if (currentCaffeine + caffeineTaken <= 300)
                {
                    caffeineTaken += currentCaffeine;
                }
                else
                {
                    caffeineTaken = Math.Max(0, caffeineTaken - 30);
                    energyDrinks.Enqueue(currentEnergyDrink);
                }
            }

            Console.WriteLine(energyDrinks.Any()
                ? $"Drinks left: {string.Join(", ", energyDrinks)}"
                : "At least Stamat wasn't exceeding the maximum caffeine.");
            Console.WriteLine($"Stamat is going to sleep with {caffeineTaken} mg caffeine.");
        }
    }
}
