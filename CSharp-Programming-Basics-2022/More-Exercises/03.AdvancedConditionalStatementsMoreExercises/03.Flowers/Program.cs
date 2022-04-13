using System;

namespace _03.Flowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemums = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char holiday = char.Parse(Console.ReadLine());
            double price = 0;

            if (season == "Spring" || season == "Summer")
            {
                price = chrysanthemums * 2 + roses * 4.1 + tulips * 2.5;
            }
            else if (season == "Autumn" || season == "Winter")
            {
                price = chrysanthemums * 3.75 + roses * 4.5 + tulips * 4.15;
            }

            if (holiday == 'Y')
            {
                price += 0.15 * price;
            }

            if (season == "Spring" && tulips > 7)
            {
                price -= 0.05 * price;
            }
            else if (season == "Winter" && roses >= 10)
            {
                price -= 0.1 * price;
            }

            if (chrysanthemums + roses + tulips > 20)
            {
                price -= 0.2 * price;
            }
            price += 2;

            Console.WriteLine($"{price:f2}");
        }
    }
}
