using System;
using System.Collections.Generic;
using System.Numerics;

namespace _01.AnonymousDownsite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfWebsites = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            decimal totalMoneyLoss = 0;

            List<string> hackedWebsites = new List<string>();

            for (int i = 0; i < countOfWebsites; i++)
            {
                string[] websiteData = Console.ReadLine().Split();

                string name = websiteData[0];
                decimal visits = decimal.Parse(websiteData[1]);
                decimal commercialPricePerVisit = decimal.Parse(websiteData[2]);

                totalMoneyLoss += visits * commercialPricePerVisit;

                hackedWebsites.Add(name);
            }

            foreach (var hackedWebsite in hackedWebsites)
            {
                Console.WriteLine(hackedWebsite);
            }

            Console.WriteLine($"Total Loss: {totalMoneyLoss:f20}");
            Console.WriteLine($"Security Token: {BigInteger.Pow(securityKey, countOfWebsites)}");
        }
    }
}
