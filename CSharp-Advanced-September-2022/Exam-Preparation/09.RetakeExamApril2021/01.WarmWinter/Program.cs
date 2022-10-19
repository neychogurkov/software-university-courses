using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            List<int> sets = new List<int>();

            while (hats.Any() && scarfs.Any())
            {
                int currentHat = hats.Pop();
                int currentScarf = scarfs.Peek();

                if (currentHat > currentScarf)
                {
                    int setPrice = currentHat + currentScarf;
                    sets.Add(setPrice);
                    scarfs.Dequeue();
                }
                else if (currentScarf == currentHat)
                {
                    hats.Push(currentHat + 1);
                    scarfs.Dequeue();
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
