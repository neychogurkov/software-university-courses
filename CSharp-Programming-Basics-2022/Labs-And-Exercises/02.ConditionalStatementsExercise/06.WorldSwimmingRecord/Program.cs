using System;

namespace _06.WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double currentRecord = double.Parse(Console.ReadLine());
            double distance = double.Parse(Console.ReadLine());
            double timePerMeter = double.Parse(Console.ReadLine());
            double newTime = distance * timePerMeter + Math.Floor(distance / 15) * 12.5;
            if (newTime < currentRecord)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {newTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {newTime-currentRecord:f2} seconds slower.");
            }
        }
    }
}
