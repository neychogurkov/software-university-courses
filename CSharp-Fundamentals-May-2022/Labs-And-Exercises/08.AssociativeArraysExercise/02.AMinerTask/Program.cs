using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourcesQuantities = new Dictionary<string, int>();

            while (true)
            {
                string resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (!resourcesQuantities.ContainsKey(resource))
                {
                    resourcesQuantities[resource] = 0;
                }

                resourcesQuantities[resource] += quantity;
            }

            foreach (var kvp in resourcesQuantities)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
