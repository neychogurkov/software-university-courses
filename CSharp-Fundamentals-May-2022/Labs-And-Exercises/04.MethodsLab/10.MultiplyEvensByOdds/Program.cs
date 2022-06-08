using System;
using System.Net;

namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMultiplicationOfEvensAndOdds(number));
        }

        static int GetMultiplicationOfEvensAndOdds(int number)
        {
            return GetSumOfEvenDigits(number) * GetSumOfOddDigits(number);
        }

        static int GetSumOfEvenDigits(int number)
        {
            int evenSum = 0;
            while (number != 0)
            {
                int currentDigit = Math.Abs(number % 10);
                if (currentDigit % 2 == 0)
                {
                    evenSum += currentDigit;
                }
                number /= 10;
            }

            return evenSum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int oddSum = 0;
            while (number != 0)
            {
                int currentDigit = Math.Abs(number % 10);
                if (currentDigit % 2 != 0)
                {
                    oddSum += currentDigit;
                }
                number /= 10;
            }

            return oddSum;
        }
    }
}
