using System;

namespace _09.SumOfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int number = 1;

            for (int i = 0; i < n; i++)
            {
                sum += number;
                Console.WriteLine(number);
                number += 2;
            }

            Console.WriteLine("Sum: " + sum);
        }
    }
}
