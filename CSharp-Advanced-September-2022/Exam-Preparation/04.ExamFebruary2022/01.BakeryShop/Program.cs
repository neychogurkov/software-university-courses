using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waterQuantities = new Queue<double>(Console.ReadLine().Split().Select(double.Parse));
            Stack<double> flourQuantities = new Stack<double>(Console.ReadLine().Split().Select(double.Parse));

            Dictionary<double, string> productsByWaterPercentage = new Dictionary<double, string>()
            {
                {50,"Croissant"},
                {40,"Muffin"},
                {30,"Baguette"},
                {20,"Bagel"}
            };
            Dictionary<string, double> productsQuantities = new Dictionary<string, double>();

            while (waterQuantities.Any() && flourQuantities.Any())
            {
                double currentWaterQuantity = waterQuantities.Dequeue();
                double currentFlourQuantity = flourQuantities.Pop();
                double waterPercentage = currentWaterQuantity / (currentWaterQuantity + currentFlourQuantity) * 100;

                if (productsByWaterPercentage.ContainsKey(waterPercentage))
                {
                    string product = productsByWaterPercentage[waterPercentage];
                    AddProduct(productsQuantities, product);
                }
                else
                {
                    flourQuantities.Push(currentFlourQuantity - currentWaterQuantity);
                    AddProduct(productsQuantities, "Croissant");
                }
            }

            foreach (var (product, quantity) in productsQuantities.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{product}: {quantity}");
            }

            Console.WriteLine($"Water left: {(waterQuantities.Any() ? string.Join(", ", waterQuantities) : "None")}");
            Console.WriteLine($"Flour left: {(flourQuantities.Any() ? string.Join(", ", flourQuantities) : "None")}");
        }

        static void AddProduct(Dictionary<string, double> productsQuantities, string product)
        {
            if (!productsQuantities.ContainsKey(product))
            {
                productsQuantities[product] = 0;
            }

            productsQuantities[product]++;
        }
    }
}
