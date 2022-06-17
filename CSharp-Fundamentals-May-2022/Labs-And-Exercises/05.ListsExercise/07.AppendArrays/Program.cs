using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> arrays = Console.ReadLine().Split('|').Reverse().ToList();
            List<int> numbers = new List<int>();

            foreach (var array in arrays)
            {
                numbers.AddRange(array.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
