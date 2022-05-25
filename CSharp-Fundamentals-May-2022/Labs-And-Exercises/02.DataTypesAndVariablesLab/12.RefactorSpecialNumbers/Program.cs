using System;

namespace _12.RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool result = false;
            for (int i = 1; i <= n; i++)
            {
                int digitSum = 0;
                int currentDigit = i;
                while (i > 0)
                {
                    digitSum += i % 10;
                    i /= 10;
                }
                result = (digitSum == 5) || (digitSum == 7) || (digitSum == 11);
                Console.WriteLine("{0} -> {1}", currentDigit, result);
                i = currentDigit;
            }

        }
    }
}
