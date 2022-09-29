using System;
using System.Linq;

namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Predicate<string> hasValidLength = x => x.Length <= length;

            print(names.Where(x => hasValidLength(x)).ToArray());
        }
    }
}
