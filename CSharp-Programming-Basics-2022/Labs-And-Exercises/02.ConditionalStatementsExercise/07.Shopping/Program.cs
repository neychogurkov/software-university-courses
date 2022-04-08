using System;

namespace _07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int graphicsCards = int.Parse(Console.ReadLine());
            int GPUs = int.Parse(Console.ReadLine());
            int RAMs = int.Parse(Console.ReadLine());
            double graphicsCardsPrice = graphicsCards * 250;
            double GPUsPrice = 0.35 * graphicsCardsPrice*GPUs;
            double RAMsPrice = 0.1 * graphicsCardsPrice*RAMs;
            double totalPrice = graphicsCardsPrice + GPUsPrice + RAMsPrice;
            if (graphicsCards > GPUs)
            {
                totalPrice -= 0.15 * totalPrice;
            }
            double diff = Math.Abs(budget - totalPrice);
            if (budget >= totalPrice)
            {
                Console.WriteLine($"You have {diff:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {diff:f2} leva more!");
            }
        }
    }
}
