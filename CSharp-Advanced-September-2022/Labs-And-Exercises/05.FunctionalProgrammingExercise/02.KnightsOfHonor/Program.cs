using System;
using System.Linq;

namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = input => Console.WriteLine($"Sir {input}");

            string[] input = Console.ReadLine().Split();

            foreach (var item in input)
            {
                print(item);
            }
        }
    }
}
