using System;

namespace _05.SmallShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;
            switch (product)
            {
                case "coffee":
                    switch (city)
                    {
                        case "Sofia":
                            price = 0.5;
                            break;
                        case "Plovdiv":
                            price = 0.4;
                            break;
                        case "Varna":
                            price = 0.45;
                            break;
                    }
                    break;
                case "water":
                    switch (city)
                    {
                        case "Sofia":
                            price = 0.8;
                            break;
                        case "Plovdiv":
                            price = 0.7;
                            break;
                        case "Varna":
                            price = 0.7;
                            break;
                    }
                    break;
                case "beer":
                    switch (city)
                    {
                        case "Sofia":
                            price = 1.2;
                            break;
                        case "Plovdiv":
                            price = 1.15;
                            break;
                        case "Varna":
                            price = 1.10;
                            break;
                    }
                    break;
                case "sweets":
                    switch (city)
                    {
                        case "Sofia":
                            price = 1.45;
                            break;
                        case "Plovdiv":
                            price = 1.30;
                            break;
                        case "Varna":
                            price = 1.35;
                            break;
                    }
                    break;
                case "peanuts":
                    switch (city)
                    {
                        case "Sofia":
                            price = 1.60;
                            break;
                        case "Plovdiv":
                            price = 1.50;
                            break;
                        case "Varna":
                            price = 1.55;
                            break;
                    }
                    break;
            }
            Console.WriteLine(price * quantity);
        }
    }
}
