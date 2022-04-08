using System;

namespace _04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishers = int.Parse(Console.ReadLine());
            double price = 0;

            switch (season)
            {
                case "Spring":
                    price = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    price = 4200;
                    break;
                case "Winter":
                    price = 2600;
                    break;
            }
            if (fishers <= 6)
            {
                price -= 0.1 * price;
            }
            else if (fishers >= 7 && fishers <= 11)
            {
                price -= 0.15 * price;
            }
            else
            {
                price -= 0.25 * price;
            }
            if (fishers % 2 == 0 && season != "Autumn")
            {
                price -= 0.05 * price;
            }

            double diff = Math.Abs(budget - price);
            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {diff:f2} leva.");
            }
        }
    }
}
