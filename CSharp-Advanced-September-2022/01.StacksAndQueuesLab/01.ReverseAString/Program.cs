using System;
using System.Collections.Generic;

namespace _01.ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Stack<char> reversedText = new Stack<char>();

            foreach (var ch in text)
            {
                reversedText.Push(ch);
            }

            while (reversedText.Count > 0)
            {
                Console.Write(reversedText.Pop());
            }
        }
    }
}
