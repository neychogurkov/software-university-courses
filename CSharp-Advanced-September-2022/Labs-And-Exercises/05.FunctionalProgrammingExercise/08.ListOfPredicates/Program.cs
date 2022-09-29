using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Predicate<int>> predicates = new List<Predicate<int>>();

            int rangeEnd = int.Parse(Console.ReadLine());
            HashSet<int> divisors = Console.ReadLine().Split().Select(int.Parse).ToHashSet();

            foreach (var divisor in divisors)
            {
                predicates.Add(n => n % divisor == 0);
            }

            for (int i = 1; i <= rangeEnd; i++)
            {
                bool isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        isDivisible = false;
                    }
                }

                if (isDivisible)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
