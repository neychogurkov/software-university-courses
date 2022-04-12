using System;

namespace _02.AddBags
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double luggageMoreThan20kgPrice = double.Parse(Console.ReadLine());
            double weight = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int luggageCount = int.Parse(Console.ReadLine());
            double price = 0;

            if (weight < 10)
            {
                price = 0.2 * luggageMoreThan20kgPrice;
            }
            else if (weight >= 10 && weight <= 20)
            {
                price = luggageMoreThan20kgPrice / 2;
            }
            else
            {
                price = luggageMoreThan20kgPrice;
            }

            if (days > 30)
            {
                price += 0.1 * price;
            }
            else if (days >= 7)
            {
                price += 0.15 * price;
            }
            else
            {
                price += 0.4 * price;
            }

            price *= luggageCount;

            Console.WriteLine($"The total price of bags is: {price:f2} lv. ");
        }
    }
}
