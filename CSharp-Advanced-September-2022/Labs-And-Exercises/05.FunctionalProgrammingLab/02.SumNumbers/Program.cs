using System;
using System.Linq;
using System.Security;

namespace _02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> parser = n => int.Parse(n);

            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
