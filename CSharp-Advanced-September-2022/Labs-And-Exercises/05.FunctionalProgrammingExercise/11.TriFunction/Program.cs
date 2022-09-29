using System;
using System.Linq;

namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int charSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> filter = (name, sum) => name.Sum(ch => ch) >= sum;

            Console.WriteLine(names.FirstOrDefault(n => filter(n, charSum)));
        }
    }
}
