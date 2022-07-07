using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> charactersOccurrences = new Dictionary<char, int>();
            string text = Console.ReadLine();

            foreach (var character in text)
            {
                if (character != ' ')
                {
                    if (!charactersOccurrences.ContainsKey(character))
                    {
                        charactersOccurrences[character] = 0;
                    }

                    charactersOccurrences[character]++;
                }
            }

            foreach (var kvp in charactersOccurrences)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
