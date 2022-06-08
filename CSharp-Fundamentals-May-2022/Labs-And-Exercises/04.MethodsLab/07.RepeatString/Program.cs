using System;

namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repetitions = int.Parse(Console.ReadLine());
            Console.WriteLine(RepeatStringNTimes(input, repetitions));
        }

        static string RepeatStringNTimes(string text, int times)
        {
            string result = string.Empty;

            for (int i = 0; i < times; i++)
            {
                result += text;
            }

            return result;
        }
    }
}
