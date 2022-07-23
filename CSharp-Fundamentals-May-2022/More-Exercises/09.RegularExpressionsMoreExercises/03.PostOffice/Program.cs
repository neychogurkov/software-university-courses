using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('|');

            Dictionary<char, Word> words = new Dictionary<char, Word>();

            string firstPart = input[0];
            string secondPart = input[1];
            string[] thirdPart = input[2].Split();

            string firstPartPattern = @"(#|\$|%|\*|&)(?<capitalLetters>[A-Z]+)\1";
            string secondPartPattern = @"(?<asciiCode>\d{2}):(?<length>\d{2,})";

            Match firstPartMatch = Regex.Match(firstPart, firstPartPattern);

            if (firstPartMatch.Success)
            {
                foreach (var letter in firstPartMatch.Groups["capitalLetters"].Value)
                {
                    words[letter] = new Word { Length = 1, Text = letter.ToString() };
                }
            }

            MatchCollection secondPartMatches = Regex.Matches(secondPart, secondPartPattern);

            foreach (Match match in secondPartMatches)
            {
                char letter = (char)int.Parse(match.Groups["asciiCode"].Value);

                if (char.IsLetter(letter))
                {
                    if (words.ContainsKey(letter))
                    {
                        if (words[letter].Length == 1)
                        {
                            words[letter].Length += int.Parse(match.Groups["length"].Value);
                        }
                    }
                }
            }

            foreach (var word in thirdPart)
            {
                if (words.ContainsKey(word[0]))
                {
                    if (words[word[0]].Length == word.Length)
                    {
                        words[word[0]].Text += word.Substring(1);
                    }
                }
            }

            foreach (var word in words)
            {
                Console.WriteLine(word.Value.Text);
            }
        }
    }

    class Word
    {
        public int Length { get; set; }
        public string Text { get; set; }
    }
}
