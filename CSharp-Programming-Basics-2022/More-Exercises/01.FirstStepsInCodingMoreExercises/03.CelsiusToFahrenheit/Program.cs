using System;

namespace _03.CelsiusToFahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double degrees = double.Parse(Console.ReadLine());
            double fahrenheit = degrees * 9 / 5 + 32;

            Console.WriteLine($"{fahrenheit:f2}");
        }
    }
}
