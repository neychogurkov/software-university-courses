using System;

namespace _01.PoolDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double entranceFee = double.Parse(Console.ReadLine());
            double loungePrice = double.Parse(Console.ReadLine());
            double umbrellaPrice = double.Parse(Console.ReadLine());
            double totalPrice = people * entranceFee + Math.Ceiling((double)people / 2) * umbrellaPrice + Math.Ceiling(0.75 * people) * loungePrice;

            Console.WriteLine($"{totalPrice:f2} lv.");
        }
    }
}
