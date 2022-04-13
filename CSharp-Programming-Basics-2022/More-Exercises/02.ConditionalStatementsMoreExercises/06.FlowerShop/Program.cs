using System;

namespace _06.FlowerShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int magnolias = int.Parse(Console.ReadLine());
            int hyacinths = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cactuses = int.Parse(Console.ReadLine());
            double giftPrice = double.Parse(Console.ReadLine());

            double profit = magnolias * 3.25 + hyacinths * 4 + roses * 3.5 + cactuses * 8;
            profit -= 0.05 * profit;
            double diff = Math.Abs(profit - giftPrice);

            if (profit >= giftPrice)
            {
                Console.WriteLine($"She is left with {Math.Floor(diff)} leva.");
            }
            else
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(diff)} leva.");
            }
        }
    }
}
