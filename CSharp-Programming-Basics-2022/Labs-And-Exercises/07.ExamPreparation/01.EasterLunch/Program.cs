using System;

namespace _01.EasterLunch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int easterBreads = int.Parse(Console.ReadLine());
            int eggshells = int.Parse(Console.ReadLine());
            int kilosOfCookies = int.Parse(Console.ReadLine());
            int eggs = eggshells * 12;

            double totalPrice = easterBreads * 3.2 + eggshells * 4.35 + kilosOfCookies * 5.4 + 0.15 * eggs;
            Console.WriteLine($"{totalPrice:f2}");

        }
    }
}
