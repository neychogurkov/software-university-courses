using System;

namespace _04.VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double vegetablesPricePerKilo = double.Parse(Console.ReadLine());
            double fruitsPricePerKilo = double.Parse(Console.ReadLine());
            int kilosOfVegetables = int.Parse(Console.ReadLine());
            int kilosOfFruits = int.Parse(Console.ReadLine());
            double income = (vegetablesPricePerKilo * kilosOfVegetables + fruitsPricePerKilo * kilosOfFruits)/1.94;

            Console.WriteLine($"{income:f2}");
        }
    }
}
