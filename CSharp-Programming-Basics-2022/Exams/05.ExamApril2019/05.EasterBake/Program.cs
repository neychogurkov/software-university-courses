using System;

namespace _05.EasterBake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int easterBreads = int.Parse(Console.ReadLine());
            int totalSugarUsed = 0;
            int totalFlourUsed = 0;
            double sugarPackets = 0;
            double flourPackets = 0;
            int maxFlourQuantity = int.MinValue;
            int maxSugarQuantity = int.MinValue;

            for (int i = 0; i < easterBreads; i++)
            {
                int sugarUsed = int.Parse(Console.ReadLine());
                int flourUsed = int.Parse(Console.ReadLine());
                totalSugarUsed += sugarUsed;
                totalFlourUsed += flourUsed;

                if (maxSugarQuantity < sugarUsed)
                {
                    maxSugarQuantity = sugarUsed;
                }

                if (maxFlourQuantity < flourUsed)
                {
                    maxFlourQuantity = flourUsed;
                }
            }
            sugarPackets = Math.Ceiling((double)totalSugarUsed / 950);
            flourPackets = Math.Ceiling((double)totalFlourUsed/ 750);

            Console.WriteLine($"Sugar: {sugarPackets}");
            Console.WriteLine($"Flour: {flourPackets}");
            Console.WriteLine($"Max used flour is {maxFlourQuantity} grams, max used sugar is {maxSugarQuantity} grams.");
        }
    }
}
