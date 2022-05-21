using System;
using System.Linq;

namespace _04.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string reversed = new string(text.ToCharArray().Reverse().ToArray());
            Console.WriteLine(reversed);
        }
    }
}
