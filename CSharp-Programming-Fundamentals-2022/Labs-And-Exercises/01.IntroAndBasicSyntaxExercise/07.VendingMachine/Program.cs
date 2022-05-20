using System;

namespace _07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // coins 0.1 0.2 0.5 1 and 2
            string command = Console.ReadLine();
            double money = 0;
            while (command != "Start")
            {
                double coin = double.Parse(command);
                if (coin != 0.1 && coin != 0.2 && coin != 0.5 && coin != 1 && coin != 2)
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                else
                {
                    money += coin;
                }

                command = Console.ReadLine();
            }

            string product = Console.ReadLine();
            while (product != "End")
            {
                double price = 0;

                if (product == "Nuts")
                {
                    price = 2;
                }
                else if (product == "Water")
                {
                    price = 0.7;
                }
                else if (product == "Crisps")
                {
                    price = 1.5;
                }
                else if (product == "Soda")
                {
                    price = 0.8;
                }
                else if (product == "Coke")
                {
                    price = 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    product = Console.ReadLine();
                    continue;
                }

                if (price > money)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    money -= price;
                }
                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {money:f2}");
        }
    }
}
