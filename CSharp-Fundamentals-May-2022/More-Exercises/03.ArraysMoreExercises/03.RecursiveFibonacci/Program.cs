using System;

namespace _03.RecursiveFibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacci(number));
        }

        static int GetFibonacci(int number)
        {
            if (number == 1 || number == 2)
            {
                return 1;
            }

            return GetFibonacci(number - 1) + GetFibonacci(number - 2);

        }
    }
}
