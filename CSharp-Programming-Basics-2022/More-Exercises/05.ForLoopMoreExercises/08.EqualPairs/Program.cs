using System;

namespace _08.EqualPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int maxDiff = 0;
            int previousSum = 0;

            for (int i = 0; i < n; i++)
            {
                int firstNumber = int.Parse(Console.ReadLine());
                int secondNumber = int.Parse(Console.ReadLine());
                int sum = firstNumber + secondNumber;
                int diff = Math.Abs(sum - previousSum);

                if (i > 0)
                {
                    if (diff > maxDiff)
                    {
                        maxDiff = diff;
                    }
                }

                previousSum = firstNumber + secondNumber;
            }

            if (maxDiff == 0)
            {
                Console.WriteLine($"Yes, value={previousSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={maxDiff}");
            }
        }
    }
}
