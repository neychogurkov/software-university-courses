using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshnessLevels = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Dictionary<int, string> dishesByFreshnessLevel = new Dictionary<int, string>()
            {
                {150, "Dipping sauce"},
                {250, "Green salad"},
                {300, "Chocolate cake"},
                {400, "Lobster"},
            };
            SortedDictionary<string, int> dishes = new SortedDictionary<string, int>()
            {
                {"Dipping sauce", 0},
                {"Green salad", 0},
                {"Chocolate cake", 0},
                {"Lobster", 0},
            };

            while (ingredients.Any() && freshnessLevels.Any())
            {
                int currentIgredient = ingredients.Dequeue();

                if (currentIgredient == 0)
                {
                    continue;
                }

                int currentFreshnessLevel = freshnessLevels.Pop();
                int totalFreshnessLevel = currentIgredient * currentFreshnessLevel;

                if (dishesByFreshnessLevel.ContainsKey(totalFreshnessLevel))
                {
                    string dish = dishesByFreshnessLevel[totalFreshnessLevel];
                    dishes[dish]++;
                }
                else
                {
                    ingredients.Enqueue(currentIgredient + 5);
                }
            }

            if (dishes.Values.Sum() >= 4 && !dishes.Values.Any(d => d == 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishes.Where(d => d.Value > 0))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }
        }
    }
}
