using System;

namespace _04.SumOfTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int combinationsCount = 0;

            for(int i = start; i <= end; i++)
            {
                for(int j = start; j <= end; j++)
                {
                    combinationsCount++;

                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{combinationsCount} ({i} + {j} = {magicNumber})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{combinationsCount} combinations - neither equals {magicNumber}");
        }
    }
}
