using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string pattern = @"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1";
            
            int coolThreshold = GetCoolThreshold(text);

            MatchCollection emojis = Regex.Matches(text, pattern);

            List<string> coolEmojis = GetCoolEmojis(emojis, coolThreshold);

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");

            foreach (var coolEmoji in coolEmojis)
            {
                Console.WriteLine(coolEmoji);
            }
        }

        static int GetCoolThreshold(string text)
        {
            int coolThreshold = 1;

            int[] digits = text.Where(Char.IsDigit).Select(ch => int.Parse(ch.ToString())).ToArray();

            foreach (var digit in digits)
            {
                coolThreshold *= digit;
            }

            return coolThreshold;
        }

        static List<string> GetCoolEmojis(MatchCollection emojis, int coolThreshold)
        {
            List<string> coolEmojis = new List<string>();

            foreach (Match emoji in emojis)
            {
                int coolness = emoji.Groups["emoji"].Value.Sum(ch => ch);

                if (coolness > coolThreshold)
                {
                    coolEmojis.Add(emoji.Value);
                }
            }

            return coolEmojis;
        }
    }
}
