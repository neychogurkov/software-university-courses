using System;

namespace _01.OscarsCeremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());
            double figurinesPrice = rent - 0.3 * rent;
            double cateringPrice = figurinesPrice - 0.15 * figurinesPrice;
            double soundPrice = 0.5 * cateringPrice;
            double totalPrice = rent + figurinesPrice + cateringPrice + soundPrice;
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
