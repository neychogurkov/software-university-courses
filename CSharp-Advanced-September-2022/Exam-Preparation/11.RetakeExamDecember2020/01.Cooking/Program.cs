using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Dictionary<int, string> foodByValue = new Dictionary<int, string>()
            {
                {25, "Bread"},
                {50, "Cake"},
                {75, "Pastry"},
                {100, "Fruit Pie"},
            };

            SortedDictionary<string, int> food = new SortedDictionary<string, int>()
            {
                {"Bread", 0},
                {"Cake", 0},
                {"Pastry", 0},
                {"Fruit Pie", 0},
            };

            while (liquids.Any() && ingredients.Any())
            {
                int currentLiquid = liquids.Dequeue();
                int currentIngredient = ingredients.Pop();

                if (foodByValue.ContainsKey(currentLiquid + currentIngredient))
                {
                    string foodType = foodByValue[currentLiquid + currentIngredient];
                    food[foodType]++;
                }
                else
                {
                    ingredients.Push(currentIngredient + 3);
                }
            }

            Console.WriteLine(food.Any(f => f.Value == 0)
                ? "Ugh, what a pity! You didn't have enough materials to cook everything."
                : "Wohoo! You succeeded in cooking all the food!");
            Console.WriteLine($"Liquids left: {(liquids.Any() ? string.Join(", ", liquids) : "none")}");
            Console.WriteLine($"Ingredients left: {(ingredients.Any() ? string.Join(", ", ingredients) : "none")}");

            foreach (var item in food)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
