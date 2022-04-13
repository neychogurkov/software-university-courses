using System;

namespace _03.Harvest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int vineyardArea = int.Parse(Console.ReadLine());
            double grapesForOneSquareMeter = double.Parse(Console.ReadLine());
            int neededWineLiters = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double grapes = vineyardArea * grapesForOneSquareMeter;
            double wine = 0.4 * grapes / 2.5;
            double diff = Math.Abs(neededWineLiters - wine);

            if (wine >= neededWineLiters)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wine)} liters.");
                Console.WriteLine($"{Math.Ceiling(diff)} liters left -> {Math.Ceiling(diff/workers)} liters per person.");
            }
            else
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(diff)} liters wine needed.");
            }

        }
    }
}
