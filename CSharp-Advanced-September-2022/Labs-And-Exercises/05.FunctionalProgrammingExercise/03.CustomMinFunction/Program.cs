using System;
using System.Linq;
using System.Reflection;

namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> getMin = x => x.Min();

            Console.WriteLine(getMin(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray()));
        }
    }
}
