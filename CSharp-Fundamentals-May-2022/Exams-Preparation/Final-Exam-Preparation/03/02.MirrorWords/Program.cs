using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<KeyValuePair<string, string>> mirrorWords = new List<KeyValuePair<string, string>>();

            string pattern = @"([@#])(?<firstWord>[A-Za-z]{3,})\1\1(?<secondWord>[A-Za-z]{3,})\1";

            MatchCollection validPairs = Regex.Matches(text, pattern);

            if (validPairs.Count > 0)
            {
                Console.WriteLine($"{validPairs.Count} word pairs found!");

                foreach (Match validPair in validPairs)
                {
                    string firstWord = validPair.Groups["firstWord"].Value;
                    string secondWord = validPair.Groups["secondWord"].Value;

                    if (firstWord == new string(secondWord.Reverse().ToArray()))
                    {
                        mirrorWords.Add(new KeyValuePair<string, string>(firstWord, secondWord));
                    }
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (mirrorWords.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords.Select(kvp => $"{kvp.Key} <=> {kvp.Value}")));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
