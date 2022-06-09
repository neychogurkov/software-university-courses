using System;

namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            PrintTopNumbers(end);
        }

        static void PrintTopNumbers(int end)
        {
            for (int i = 1; i <= end; i++)
            {
                bool isTopNumber = true;
                int number = i;
                int digitSum = 0;
                int oddDigits = 0;

                while (number != 0)
                {
                    digitSum += number % 10;

                    if ((number % 10) % 2 != 0)
                    {
                        oddDigits++;
                    }

                    number /= 10;
                }

                if (digitSum % 8 != 0 || oddDigits == 0)
                {
                    isTopNumber = false;
                }

                if (isTopNumber)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
