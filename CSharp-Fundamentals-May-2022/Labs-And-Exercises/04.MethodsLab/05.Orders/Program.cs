using System;
using System.Threading.Channels;

namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            PrintTotalPrice(product, quantity);
        }

        static void PrintTotalPrice(string product, int quantity)
        {
            double price = 0;
            switch (product)
            {
                case "coffee":
                    price = 1.5;
                    break;
                case "water":
                    price = 1;
                    break;
                case "coke":
                    price = 1.4;
                    break;
                case "snacks":
                    price = 2;
                    break;
            }

            price *= quantity;

            Console.WriteLine($"{price:f2}");
        }
    }
}
