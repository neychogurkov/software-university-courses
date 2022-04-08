using System;

namespace _01.USDtoBGN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyInUSD = double.Parse(Console.ReadLine());
            double moneyInBGN = moneyInUSD * 1.79549;
            Console.WriteLine(moneyInBGN);
        }
    }
}
