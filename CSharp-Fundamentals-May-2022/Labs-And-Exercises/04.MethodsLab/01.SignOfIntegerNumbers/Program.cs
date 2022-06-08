using System;

namespace _01.SignOfIntegerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintSignOfNumber(number);
        }

        static void PrintSignOfNumber(int number)
        {
            if (number > 0)
            {
                Console.WriteLine($"The number {number} is positive. ");
            }
            else if (number == 0)
            {
                Console.WriteLine($"The number {number} is zero. ");
            }
            else
            {
                Console.WriteLine($"The number {number} is negative. ");
            }
        }
    }
}
