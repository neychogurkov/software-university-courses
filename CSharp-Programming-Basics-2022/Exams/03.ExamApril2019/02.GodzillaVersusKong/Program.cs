using System;

namespace _02.GodzillaVersusKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extras = int.Parse(Console.ReadLine());
            double clothingPrice = double.Parse(Console.ReadLine()) * extras;
            double decorationPrice = 0.1 * budget;

            if (extras > 150)
            {
                clothingPrice -= 0.1 * clothingPrice;
            }
            double moneyNeeded = clothingPrice + decorationPrice;

            if (moneyNeeded <= budget)
            {
                Console.WriteLine($"Action!\nWingard starts filming with {budget-moneyNeeded:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money!\nWingard needs {moneyNeeded-budget:f2} leva more.");
            }
        }
    }
}
