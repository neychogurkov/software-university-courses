using System;

namespace _02.Safari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double fuelNeeded = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            double totalPrice = fuelNeeded * 2.1 + 100;

            if (day == "Saturday")
            {
                totalPrice -= 0.1 * totalPrice;
            }
            else if (day == "Sunday")
            {
                totalPrice -= 0.2 * totalPrice;
            }

            double diff = Math.Abs(totalPrice - budget);

            if (totalPrice <= budget)
            {
                Console.WriteLine($"Safari time! Money left: {diff:f2} lv. ");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {diff:f2} lv.");
            }
        }
    }
}
