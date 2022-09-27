using System;
using System.Linq;
using System.Xml;

namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isFirstLetterCapital = w => char.IsUpper(w[0]);

            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(w => isFirstLetterCapital(w))
                .ToArray()));
        }
    }
}
