using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersOccurrences = new Dictionary<int, int>();

            int numbersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numbersOccurrences.ContainsKey(number))
                {
                    numbersOccurrences[number] = 0;
                }

                numbersOccurrences[number]++;
            }

            Console.WriteLine(numbersOccurrences.First(n => n.Value % 2 == 0).Key);
        }
    }
}
