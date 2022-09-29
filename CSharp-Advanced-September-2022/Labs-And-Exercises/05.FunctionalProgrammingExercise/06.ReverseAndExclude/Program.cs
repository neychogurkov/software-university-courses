using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int divisor = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = n => n % divisor == 0;

            Console.WriteLine(string.Join(" ", numbers
                .Where(n => !isDivisible(n))
                .Reverse()
                .ToArray()));
        }
    }
}
