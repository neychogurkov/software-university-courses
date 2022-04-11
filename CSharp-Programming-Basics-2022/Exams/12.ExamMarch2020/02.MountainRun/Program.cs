using System;

namespace _02.MountainRun
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double currentRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timeForOneMeter = double.Parse(Console.ReadLine());
            double newTime = distance * timeForOneMeter + Math.Floor(distance / 50) * 30;

            if (newTime < currentRecord)
            {
                Console.WriteLine($"Yes! The new record is {newTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {newTime-currentRecord:f2} seconds slower.");
            }
        }
    }
}
