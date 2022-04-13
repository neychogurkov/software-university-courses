using System;

namespace _05.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string accommodation = string.Empty;
            string location = string.Empty;
            double price = 0;

            if (budget <= 1000)
            {
                accommodation = "Camp";

                if (season == "Summer")
                {
                    location = "Alaska";
                    price = 0.65 * budget;
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                    price = 0.45 * budget;
                }
            }
            else if (budget <= 3000)
            {
                accommodation = "Hut";

                if (season == "Summer")
                {
                    location = "Alaska";
                    price = 0.8 * budget;
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                    price = 0.6 * budget;
                }
            }
            else
            {
                accommodation = "Hotel";

                if (season == "Summer")
                {
                    location = "Alaska";
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                }
                price = 0.9 * budget;
            }

            Console.WriteLine($"{location} - {accommodation} - {price:f2}");
        }
    }
}
