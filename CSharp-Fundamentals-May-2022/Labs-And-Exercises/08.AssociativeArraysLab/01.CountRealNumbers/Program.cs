using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> numbersOccurrences = new SortedDictionary<int, int>();

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (var number in numbers)
            {
                if (!numbersOccurrences.ContainsKey(number)) 
                {
                    numbersOccurrences[number] = 0;
                }

                numbersOccurrences[number]++;
            }

            foreach (var kvp in numbersOccurrences)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
