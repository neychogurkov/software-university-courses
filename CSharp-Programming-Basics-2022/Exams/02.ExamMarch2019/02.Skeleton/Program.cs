using System;

namespace _02.Skeleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            int secondsPerHundredMeters = int.Parse(Console.ReadLine());
            int time = minutes * 60 + seconds;
            double newTime = (length / 100) * secondsPerHundredMeters - length / 120 * 2.5;

            if (newTime <= time)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {newTime:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {newTime - time:f3} second slower.");
            }
        }
    }
}
