using System;

namespace _01.SeriesCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            int seasons = int.Parse(Console.ReadLine());
            int episodes = int.Parse(Console.ReadLine());
            double durationWithoutAds = double.Parse(Console.ReadLine());
            double durationWithAds = durationWithoutAds + 0.2 * durationWithoutAds;

            double totalTime = seasons * episodes * durationWithAds + seasons * 10;
            Console.WriteLine($"Total time needed to watch the {seriesName} series is {Math.Floor(totalTime)} minutes.");
        }
    }
}
