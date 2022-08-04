using System;
using System.Collections;
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

            List<string> coolEmojis = new List<string>();

            int coolThreshold = 1;

            int[] digits = text.Where(char.IsDigit).Select(ch => int.Parse(ch.ToString())).ToArray();

            foreach (var digit in digits)
            {
                coolThreshold *= digit;
            }

            MatchCollection validEmojis = Regex.Matches(text, pattern);

            foreach (Match validEmoji in validEmojis)
            {
                string emoji = validEmoji.Groups["emoji"].Value;
                int coolness = emoji.Sum(ch => ch);

                if (coolness > coolThreshold)
                {
                    coolEmojis.Add(validEmoji.Value);
                }
            }

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{validEmojis.Count} emojis found in the text. The cool ones are:");

            foreach (var coolEmoji in coolEmojis)
            {
                Console.WriteLine(coolEmoji);
            }
        }
    }
}
