using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MessageTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfInputs = int.Parse(Console.ReadLine());

            string pattern = @"!(?<command>[A-Z][a-z]{2,})!:\[(?<text>[A-Za-z]{8,})\]";


            for (int i = 0; i < countOfInputs; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string command = match.Groups["command"].Value;
                    string text = match.Groups["text"].Value;

                    int[] translatedText = text.Select(ch => (int)ch).ToArray();

                    Console.WriteLine($"{command}: {string.Join(" ", translatedText)}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
