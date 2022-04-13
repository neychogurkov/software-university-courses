using System;

namespace _01.MatchTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string ticketType = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());
            double price = 0;

            if (ticketType == "VIP")
            {
                price = 499.99;
            }
            else if (ticketType == "Normal")
            {
                price = 249.99;
            }

            price *= people;

            if (people >= 1 && people <= 4)
            {
                price += 0.75 * budget;
            }
            else if (people >= 5 && people <= 9)
            {
                price += 0.6 * budget;
            }
            else if (people >= 10 && people <= 24)
            {
                price += budget / 2;
            }
            else if (people >= 25 && people <= 49)
            {
                price += 0.4 * budget;
            }
            else
            {
                price += 0.25 * budget;
            }

            double diff = Math.Abs(price - budget);

            if (price <= budget)
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
