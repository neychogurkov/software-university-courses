using System;

namespace _10.LowerOrUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string character = Console.ReadLine();
            if (character == character.ToUpper())
            {
                Console.WriteLine("upper-case");
            }
            else
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
