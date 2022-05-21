using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(int.Parse(Console.ReadLine()));
            list.Add(int.Parse(Console.ReadLine()));
            list.Add(int.Parse(Console.ReadLine()));
            Console.WriteLine(String.Join(Environment.NewLine, list.OrderByDescending(n => n)));
        }
    }
}
