using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lengths = Console.ReadLine().Split();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < int.Parse(lengths[0]); i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }
            for (int i = 0; i < int.Parse(lengths[1]); i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            Console.WriteLine(string.Join(" ", firstSet.Where(n => secondSet.Contains(n))));
        }
    }
}
