using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.CustomComparator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Func<int, int, int> comparator = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }

                return x.CompareTo(y);
            };

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(numbers, (x, y) => comparator(x, y));
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
