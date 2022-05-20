using System;

namespace _06.StrongNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int n = number;
            while (n > 0)
            {
                int currentDigit = n % 10;
                int factorial = 1;
                for (int i = 1; i <= currentDigit; i++)
                {
                    factorial *= i;
                }
                sum += factorial;
                n /= 10;
            }

            if (number == sum)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
