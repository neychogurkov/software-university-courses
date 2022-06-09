using System;

namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetVowelsCount(input));
        }

        static int GetVowelsCount(string text)
        {
            int vowelsCount = 0;

            foreach (var letter in text)
            {
                if (letter == 'a' || letter == 'e' || letter == 'o' || letter == 'u' || letter == 'i'|| letter == 'A' || letter == 'E' || letter == 'O' || letter == 'U' || letter == 'I')
                {
                    vowelsCount++;
                }
            }

            return vowelsCount;
        }
    }
}
