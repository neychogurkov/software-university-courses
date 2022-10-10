using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<int>> boxes = new List<Box<int>>();

            int integersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < integersCount; i++)
            {
                Box<int> box = new Box<int>() { Value = int.Parse(Console.ReadLine()) };
                boxes.Add(box);
            }

            int[] swapCommand = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Swap(boxes, swapCommand[0], swapCommand[1]);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }

        static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            (list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);
        }
    }
}
