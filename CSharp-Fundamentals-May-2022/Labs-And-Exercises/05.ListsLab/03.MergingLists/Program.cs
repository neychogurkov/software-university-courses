using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> mergedList = new List<int>();

            int biggerCount = Math.Min(list1.Count, list2.Count);

            for (int i = 0; i < biggerCount; i++)
            {
                mergedList.Add(list1[i]);
                mergedList.Add(list2[i]);
            }

            if (list1.Count > list2.Count)
            {
                for (int i = biggerCount; i < list1.Count; i++)
                {
                    mergedList.Add(list1[i]);
                }
            }

            else
            {
                for (int i = biggerCount; i < list2.Count; i++)
                {
                    mergedList.Add(list2[i]);
                }
            }

            Console.WriteLine(string.Join(" ", mergedList));
        }
    }
}
