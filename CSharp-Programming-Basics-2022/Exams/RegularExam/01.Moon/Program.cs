using System;

namespace _01.Moon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double averageSpeed = double.Parse(Console.ReadLine());
            double fuelNeededFor100Kms = double.Parse(Console.ReadLine());
            double totalTime = Math.Ceiling(384400 * 2 / averageSpeed) + 3;
            double totalFuelNeeded = 384400 * 2 * fuelNeededFor100Kms / 100;

            Console.WriteLine(totalTime);
            Console.WriteLine(totalFuelNeeded);
        }
    }
}
