using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int currentNumber = i;
                int digitSum = 0;
                while (currentNumber>0)
                {
                    digitSum += currentNumber % 10;
                    currentNumber /= 10;
                }

                if (digitSum == 5 || digitSum == 7 || digitSum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
