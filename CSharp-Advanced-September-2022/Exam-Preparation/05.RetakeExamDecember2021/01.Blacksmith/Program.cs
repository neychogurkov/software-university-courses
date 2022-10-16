using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steelQuantities = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> carbonQuantities = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Dictionary<int, string> swordsByResourcesNeeded = new Dictionary<int, string>()
            {
                {70, "Gladius"},
                {80, "Shamshir"},
                {90, "Katana"},
                {110, "Sabre"},
                {150, "Broadsword"}
            };
            SortedDictionary<string, int> swords = new SortedDictionary<string, int>()
            {
                {"Gladius", 0},
                {"Shamshir", 0},
                {"Katana", 0},
                {"Sabre", 0},
                {"Broadsword", 0},
            };

            while (steelQuantities.Any() && carbonQuantities.Any())
            {
                int currentSteelQuantity = steelQuantities.Dequeue();
                int currentCarbonQuantity = carbonQuantities.Pop();

                if (swordsByResourcesNeeded.ContainsKey(currentSteelQuantity + currentCarbonQuantity))
                {
                    string swordName = swordsByResourcesNeeded[currentSteelQuantity + currentCarbonQuantity];
                    swords[swordName]++;
                }
                else
                {
                    carbonQuantities.Push(currentCarbonQuantity + 5);
                }
            }

            if (swords.Values.Sum() > 0)
            {
                Console.WriteLine($"You have forged {swords.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            Console.WriteLine($"Steel left: {(steelQuantities.Any() ? string.Join(", ", steelQuantities) : "none")}");
            Console.WriteLine($"Carbon left: {(carbonQuantities.Any() ? string.Join(", ", carbonQuantities) : "none")}");

            foreach (var sword in swords.Where(s => s.Value > 0))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }
    }
}
