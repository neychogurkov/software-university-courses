using System;

namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetMiddleCharacters(input));
        }

        static string GetMiddleCharacters(string text)
        {
            string middleCharacters = string.Empty;
            if (text.Length % 2 == 0)
            {
                middleCharacters += text[text.Length / 2 - 1];
            }
            middleCharacters += text[text.Length / 2].ToString();
            
            return middleCharacters;
        }
    }
}
