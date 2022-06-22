using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            numbers = numbers
                .Where(n => n > numbers.Average())
                .OrderByDescending(n => n)
                .Take(5)
                .ToList();

            Console.WriteLine(numbers.Count > 0 ? string.Join(" ", numbers) : "No");
        }
    }
}
