using System;

namespace _06.Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double mackerelPricePerKilo = double.Parse(Console.ReadLine());
            double spratPricePerKilo = double.Parse(Console.ReadLine());
            double kilosOfBonito = double.Parse(Console.ReadLine());
            double kilosOfScad = double.Parse(Console.ReadLine());
            double kilosOfMussels = double.Parse(Console.ReadLine());

            double bonitoPricePerKilo = mackerelPricePerKilo + 0.6 * mackerelPricePerKilo;
            double scadPricePerKilo = spratPricePerKilo + 0.8 * spratPricePerKilo;
            double totalPrice = bonitoPricePerKilo * kilosOfBonito + scadPricePerKilo * kilosOfScad + 7.5 * kilosOfMussels;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
