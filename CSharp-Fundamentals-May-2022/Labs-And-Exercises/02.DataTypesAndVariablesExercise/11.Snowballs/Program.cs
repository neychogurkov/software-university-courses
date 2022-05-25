using System;
using System.Net.NetworkInformation;
using System.Numerics;

namespace _11.Snowballs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());
            int bestSnowballSnow = int.MinValue;
            int bestSnowballTime = int.MinValue;
            int bestSnowballQuality = int.MinValue;
            BigInteger bestSnowballValue = 0;

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (snowballValue > bestSnowballValue)
                {
                    bestSnowballSnow = snowballSnow;
                    bestSnowballTime = snowballTime;
                    bestSnowballValue = snowballValue;
                    bestSnowballQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowballValue} ({bestSnowballQuality})");
        }
    }
}
