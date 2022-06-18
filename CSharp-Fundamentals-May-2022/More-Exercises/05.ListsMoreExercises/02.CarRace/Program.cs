using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.CarRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            double leftTime = 0;
            double rightTime = 0;

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                leftTime += numbers[i];
                rightTime += numbers[numbers.Count - 1 - i];

                if (numbers[i] == 0)
                {
                    leftTime -= 0.2 * leftTime;
                }
                if (numbers[numbers.Count - 1 - i] == 0)
                {
                    rightTime -= 0.2 * rightTime;
                }
            }
            
            if (leftTime < rightTime)
            {
                Console.WriteLine($"The winner is left with total time: {leftTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightTime}");
            }

        }
    }
}
