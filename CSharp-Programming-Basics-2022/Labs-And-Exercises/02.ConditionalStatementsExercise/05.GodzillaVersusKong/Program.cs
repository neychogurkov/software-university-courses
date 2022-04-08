using System;

namespace _05.GodzillaVersusKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extras = int.Parse(Console.ReadLine());
            double clothingPrice = double.Parse(Console.ReadLine());
            if (extras > 150)
            {
                clothingPrice -= clothingPrice * 0.1;
            }
            double decoration = 0.1 * budget;
            double moneyNeeded = extras * clothingPrice + decoration;
            double diff = Math.Abs(budget - moneyNeeded);
            if (budget >= moneyNeeded)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {diff:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {diff:f2} leva more.");
            }
        }
    }
}
