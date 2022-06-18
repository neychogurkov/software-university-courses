using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _04.MixedUpLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> mixedList = new List<int>();
            int start = 0;
            int end = 0;

            if (firstList.Count > secondList.Count)
            {
                start = firstList[firstList.Count - 1];
                end = firstList[firstList.Count - 2];
                firstList.RemoveAt(firstList.Count-1);
                firstList.RemoveAt(firstList.Count-1);
            }
            else
            {
                start = secondList[0];
                end = secondList[1];
                secondList.RemoveAt(0);
                secondList.RemoveAt(0);
            }

            if (start > end)
            {
                int swap = start;
                start = end;
                end = swap;
            }

            for (int i = 0; i < firstList.Count; i++)
            {
                mixedList.Add(firstList[i]);
                mixedList.Add(secondList[secondList.Count - 1 - i]);
            }

            Console.WriteLine(string.Join(" ", mixedList.Where(n => n > start && n < end).OrderBy(n => n)));
        }
    }
}
