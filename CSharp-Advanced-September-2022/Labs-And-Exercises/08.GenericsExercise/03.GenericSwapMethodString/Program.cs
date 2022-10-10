using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();

            int stringsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < stringsCount; i++)
            {
                Box<string> box = new Box<string>() { Value = Console.ReadLine() };
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
