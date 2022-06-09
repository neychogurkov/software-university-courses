using System;

namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());

            if (end < start)
            {
                char temp = start;
                start = end;
                end = temp;
            }

            PrintCharactersInRange(start, end);
        }

        static void PrintCharactersInRange(char start, char end)
        {
            for (int i = start + 1; i < end; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}
