using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> isEven = x => x % 2 == 0;

            int[] tokens = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rangeStart = tokens[0];
            int rangeEnd = tokens[1];
            string command = Console.ReadLine();

            for (int i = rangeStart; i <= rangeEnd; i++)
            {
                if ((command == "even" && isEven(i)) || (command == "odd" && !isEven(i)))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
