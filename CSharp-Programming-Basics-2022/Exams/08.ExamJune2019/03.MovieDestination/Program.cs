using System;

namespace _03.MovieDestination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double price = 0;

            if (season == "Winter")
            {
                if (destination == "Dubai")
                {
                    price = 45000;
                }
                else if (destination == "Sofia")
                {
                    price = 17000;
                }
                else if (destination == "London")
                {
                    price = 24000;
                }
            }
            else if (season == "Summer")
            {
                if (destination == "Dubai")
                {
                    price = 40000;
                }
                else if (destination == "Sofia")
                {
                    price = 12500;
                }
                else if (destination == "London")
                {
                    price = 20250;
                }
            }

            price *= days;

            if (destination == "Dubai")
            {
                price -= 0.3 * price;
            }
            else if (destination == "Sofia")
            {
                price += 0.25 * price;
            }

            double diff = Math.Abs(price - budget);
            if (price <= budget)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {diff:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {diff:f2} leva more!");
            }
        }
    }
}
