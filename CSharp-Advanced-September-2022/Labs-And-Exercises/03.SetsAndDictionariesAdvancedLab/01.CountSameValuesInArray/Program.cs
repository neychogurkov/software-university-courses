using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbersOccurrences = new Dictionary<double, int>();

            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (var number in numbers)
            {
                if (!numbersOccurrences.ContainsKey(number))
                {
                    numbersOccurrences[number] = 0;
                }

                numbersOccurrences[number]++;
            }

            foreach (var (number, occurrences) in numbersOccurrences)
            {
                Console.WriteLine($"{number} - {occurrences} times");
            }
        }
    }
}
