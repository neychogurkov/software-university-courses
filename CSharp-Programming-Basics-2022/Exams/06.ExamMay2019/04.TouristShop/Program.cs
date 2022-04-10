using System;

namespace _04.TouristShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string product = Console.ReadLine();
            int productsCount = 0;
            double totalPrice = 0;

            while (product != "Stop")
            {
                double price = double.Parse(Console.ReadLine());
                productsCount++;
                if (productsCount % 3 == 0)
                {
                    price /= 2;
                }

                if (price > budget)
                {
                    Console.WriteLine("You don't have enough money!");
                    Console.WriteLine($"You need {price-budget:f2} leva!");
                    return;
                }

                budget -= price;
                totalPrice += price;

                product = Console.ReadLine();
            }

            Console.WriteLine($"You bought {productsCount} products for {totalPrice:f2} leva.");
        }
    }
}
