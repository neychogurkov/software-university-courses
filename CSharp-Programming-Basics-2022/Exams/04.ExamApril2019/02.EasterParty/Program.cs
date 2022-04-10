using System;

namespace _02.EasterParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double menuPrice = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            if (guests >= 10 && guests <= 15)
            {
                menuPrice -= 0.15 * menuPrice;
            }
            else if (guests >= 15 && guests <= 20)
            {
                menuPrice -= 0.2 * menuPrice;
            }
            else if (guests >= 20)
            {
                menuPrice -= 0.25 * menuPrice;
            }

            double cakePrice = 0.1 * budget;
            double moneyNeeded = menuPrice * guests + cakePrice;
            double diff = Math.Abs(moneyNeeded - budget);

            if (moneyNeeded <= budget)
            {
                Console.WriteLine($"It is party time! {diff:f2} leva left.");    
            }
            else
            {
                Console.WriteLine($"No party! {diff:f2} leva needed.");
            }

        }
    }
}
