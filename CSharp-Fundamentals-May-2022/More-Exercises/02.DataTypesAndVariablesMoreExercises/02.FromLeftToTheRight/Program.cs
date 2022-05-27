using System;
using System.Linq;

namespace _02.FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                long[] numbers = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                long biggerNumber = numbers[0];

                if (numbers[1] > numbers[0])
                {
                    biggerNumber = numbers[1];
                }

                long digitSum = 0;

                while (biggerNumber != 0)
                {
                    digitSum += biggerNumber % 10;
                    biggerNumber /= 10;
                }

                Console.WriteLine(Math.Abs(digitSum));
            }
        }
    }
}
