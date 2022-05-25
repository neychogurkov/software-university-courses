using System;

namespace _09.SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int days = 0;
            int extractedSpice = 0;

            if (startingYield >= 100)
            {
                while (startingYield >= 100)
                {
                    days++;
                    extractedSpice += startingYield;
                    extractedSpice -= 26;
                    startingYield -= 10;
                }

                extractedSpice -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(extractedSpice);
        }
    }
}
