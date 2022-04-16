using System;

namespace _02.ANDProcessors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int processorsNeeded = int.Parse(Console.ReadLine());
            int employees = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double processorsMade = Math.Floor((double)days * employees * 8 / 3);
            double moneyDiff = Math.Abs(processorsMade - processorsNeeded) * 110.1;

            if (processorsMade >= processorsNeeded)
            {
                Console.WriteLine($"Profit: -> {moneyDiff:f2} BGN");
            }
            else
            {
                Console.WriteLine($"Losses: -> {moneyDiff:f2} BGN");
            }
        }
    }
}
