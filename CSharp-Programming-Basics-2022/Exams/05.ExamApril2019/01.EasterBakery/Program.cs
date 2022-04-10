using System;

namespace _01.EasterBakery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double flourPricePerKilo = double.Parse(Console.ReadLine());
            double kilosOfFlour = double.Parse(Console.ReadLine());
            double kilosOfSugar = double.Parse(Console.ReadLine());
            int eggshells = int.Parse(Console.ReadLine());
            int yeastPackets = int.Parse(Console.ReadLine());

            double sugarPricePerKilo = flourPricePerKilo - 0.25 * flourPricePerKilo;
            double eggshellPrice = flourPricePerKilo + 0.1 * flourPricePerKilo;
            double yeastPacketPrice = sugarPricePerKilo - 0.8 * sugarPricePerKilo;

            double totalPrice = flourPricePerKilo * kilosOfFlour + sugarPricePerKilo * kilosOfSugar + eggshellPrice * eggshells + yeastPacketPrice * yeastPackets;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
