using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.RageQuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<textToRepeat>[^\d]+)(?<repeatCount>\d*)";

            string input = Console.ReadLine().ToUpper();
            StringBuilder message = new StringBuilder();
            StringBuilder uniqueSymbols = new StringBuilder();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string textToRepeat = match.Groups["textToRepeat"].Value;
                int repeatCount = int.Parse(match.Groups["repeatCount"].Value);

                if (repeatCount > 0)
                {
                    foreach (var character in textToRepeat)
                    {
                        if (!uniqueSymbols.ToString().Contains(character))
                        {
                            uniqueSymbols.Append(character);
                        }
                    }
                }

                for (int i = 0; i < repeatCount; i++)
                {
                    message.Append(textToRepeat);
                }
            }

            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Length}");
            Console.WriteLine(message);
        }
    }
}
