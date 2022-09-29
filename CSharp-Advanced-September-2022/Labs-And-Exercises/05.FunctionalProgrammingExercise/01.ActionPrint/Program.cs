using System;

namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = input => Console.WriteLine(input);

            string[] input = Console.ReadLine().Split();

            foreach (var item in input)
            {
                print(item);
            }
        }
    }
}
