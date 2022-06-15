using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => n >= 0)
                .Reverse()
                .ToList();

            Console.WriteLine(numbers.Count == 0 ? "empty" : string.Join(" ", numbers));

            //List<int> numbers = Console.ReadLine()
            //    .Split()
            //    .Select(int.Parse)
            //    .ToList();

            //for (int i = 0; i < numbers.Count; i++)
            //{
            //    if (numbers[i] < 0)
            //    {
            //        numbers.RemoveAt(i);
            //        i--;
            //    }
            //}
            //numbers.Reverse();

            //Console.WriteLine(numbers.Count == 0 ? "empty" : string.Join(" ", numbers));
        }
    }
}
