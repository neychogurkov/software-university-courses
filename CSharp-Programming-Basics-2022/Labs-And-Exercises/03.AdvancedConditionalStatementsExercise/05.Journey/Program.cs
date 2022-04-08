using System;

namespace _05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double moneySpent = 0;

            if (budget <= 100)
            {
                Console.WriteLine("Somewhere in Bulgaria");
                if (season == "summer")
                {
                    moneySpent = 0.3 * budget;
                    Console.WriteLine($"Camp - {moneySpent:f2}");
                }
                else if (season == "winter")
                {
                    moneySpent = 0.7 * budget;
                    Console.WriteLine($"Hotel - {moneySpent:f2}");
                }
            }
            else if (budget <= 1000)
            {
                Console.WriteLine("Somewhere in Balkans");
                if (season == "summer")
                {
                    moneySpent = 0.4 * budget;
                    Console.WriteLine($"Camp - {moneySpent:f2}");
                }
                else if (season == "winter")
                {
                    moneySpent = 0.8 * budget;
                    Console.WriteLine($"Hotel - {moneySpent:f2}");
                }
            }
            else
            {
                Console.WriteLine("Somewhere in Europe");
                moneySpent = 0.9 * budget;
                Console.WriteLine($"Hotel - {moneySpent:f2}");
            }
        }
    }
}
