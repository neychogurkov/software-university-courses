using System;

namespace _04.CarToGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string carType = string.Empty;
            double price = 0;
            if (budget <= 100)
            {
                Console.WriteLine("Economy class");

                if (season == "Summer")
                {
                    carType = "Cabrio";
                    price = 0.35 * budget;
                }
                else if (season == "Winter")
                {
                    carType = "Jeep";
                    price = 0.65 * budget;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                Console.WriteLine("Compact class");

                if (season == "Summer")
                {
                    carType = "Cabrio";
                    price = 0.45 * budget;
                }
                else if (season == "Winter")
                {
                    carType = "Jeep";
                    price = 0.8 * budget;
                }
            }
            else
            {
                Console.WriteLine("Luxury class");

                carType = "Jeep";
                price = 0.9 * budget;
            }

            Console.WriteLine($"{carType} - {price:f2}");
        }
    }
}
