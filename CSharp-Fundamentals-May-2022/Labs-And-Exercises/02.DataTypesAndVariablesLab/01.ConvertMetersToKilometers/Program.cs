using System;

namespace _01.ConvertMetersToKilometers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            decimal kilometers = (decimal)meters / 1000;
            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
