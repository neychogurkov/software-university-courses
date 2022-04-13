using System;

namespace _02.BikeRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int juniorBikers = int.Parse(Console.ReadLine());
            int seniorBikers = int.Parse(Console.ReadLine());
            string trackType = Console.ReadLine();
            double moneyRaised = 0;

            if (trackType == "trail")
            {
                moneyRaised = juniorBikers * 5.5 + seniorBikers * 7;
            }
            else if (trackType == "cross-country")
            {
                moneyRaised = juniorBikers * 8 + seniorBikers * 9.5;

                if (juniorBikers + seniorBikers >= 50)
                {
                    moneyRaised -= 0.25 * moneyRaised;
                }
            }
            else if (trackType == "downhill")
            {
                moneyRaised = juniorBikers * 12.25 + seniorBikers * 13.75;
            }
            else if (trackType == "road")
            {
                moneyRaised = juniorBikers * 20 + seniorBikers * 21.5;
            }

            moneyRaised -= 0.05 * moneyRaised;
            Console.WriteLine($"{moneyRaised:f2}");
        }
    }
}
