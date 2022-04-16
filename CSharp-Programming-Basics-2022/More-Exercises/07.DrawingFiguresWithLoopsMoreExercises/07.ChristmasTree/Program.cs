using System;

namespace _07.ChristmasTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n; i++)
            {
                Console.Write(new string(' ', n-i));
                Console.WriteLine(new string('*',i) + " | " + new string('*', i));
            }
        }
    }
}
