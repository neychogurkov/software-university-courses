using System;
using System.Linq;

namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select(p => p * 1.2)
                .Select(p => p.ToString("F2"))));
        }
    }
}
