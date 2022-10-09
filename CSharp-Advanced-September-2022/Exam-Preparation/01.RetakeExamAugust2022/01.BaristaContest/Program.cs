using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> coffeesByType = new Dictionary<string, int>();

            int[] coffeeInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] milkInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> coffeeQuantities = new Queue<int>(coffeeInput);
            Stack<int> milkQuantities = new Stack<int>(milkInput);

            while (coffeeQuantities.Any() && milkQuantities.Any())
            {
                int currentCoffeeQuantity = coffeeQuantities.Dequeue();
                int currentMilkQuantity = milkQuantities.Pop();

                switch (currentCoffeeQuantity + currentMilkQuantity)
                {
                    case 50:
                        AddCoffee(coffeesByType, "Cortado");
                        break;
                    case 75:
                        AddCoffee(coffeesByType, "Espresso");
                        break;
                    case 100:
                        AddCoffee(coffeesByType, "Capuccino");
                        break;
                    case 150:
                        AddCoffee(coffeesByType, "Americano");
                        break;
                    case 200:
                        AddCoffee(coffeesByType, "Latte");
                        break;
                    default:
                        milkQuantities.Push(currentMilkQuantity - 5);
                        break;
                }
            }

            PrintCoffees(coffeesByType, coffeeQuantities, milkQuantities);
        }

        static void AddCoffee(Dictionary<string, int> coffeesByType, string coffeeType)
        {
            if (!coffeesByType.ContainsKey(coffeeType))
            {
                coffeesByType[coffeeType] = 0;
            }
            coffeesByType[coffeeType]++;
        }

        static void PrintCoffees(Dictionary<string, int> coffeesByType, Queue<int> coffeeQuantities, Stack<int> milkQuantities)
        {
            Console.WriteLine(coffeeQuantities.Any() || milkQuantities.Any() 
                ? "Nina needs to exercise more! She didn't use all the coffee and milk!" 
                : "Nina is going to win! She used all the coffee and milk!");

            Console.WriteLine($"Coffee left: {(coffeeQuantities.Any() ? string.Join(", ", coffeeQuantities) : "none")}");
            Console.WriteLine($"Milk left: {(milkQuantities.Any() ? string.Join(", ", milkQuantities) : "none")}");

            foreach (var coffee in coffeesByType.OrderBy(c => c.Value).ThenByDescending(c => c.Key))
            {
                Console.WriteLine($"{coffee.Key}: {coffee.Value}");
            }
        }
    }
}
