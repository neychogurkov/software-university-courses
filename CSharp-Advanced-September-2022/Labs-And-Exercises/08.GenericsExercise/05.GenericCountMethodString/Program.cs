using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodString
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

            string valueToCompare = Console.ReadLine();
            Console.WriteLine(Count(boxes, valueToCompare));
        }

        static int Count<T>(List<Box<T>> list, T value) where T : IComparable<T>
        {
            return list.Count(x => x.Value.CompareTo(value) == 1);
        }
    }
}
