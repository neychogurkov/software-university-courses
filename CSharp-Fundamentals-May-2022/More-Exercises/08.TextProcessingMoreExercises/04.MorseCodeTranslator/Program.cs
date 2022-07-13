using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.MorseCodeTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, string> morseCodeToCapitalLetters = new Dictionary<char, string>
            {
                ['A'] = ".-",
                ['B'] = "-...",
                ['C'] = "-.-.",
                ['D'] = "-..",
                ['E'] = ".",
                ['F'] = "..-.",
                ['G'] = "--.",
                ['H'] = "....",
                ['I'] = "..",
                ['J'] = ".---",
                ['K'] = "-.-",
                ['L'] = ".-..",
                ['M'] = "--",
                ['N'] = "-.",
                ['O'] = "---",
                ['P'] = ".--.",
                ['Q'] = "--.-",
                ['R'] = ".-.",
                ['S'] = "...",
                ['T'] = "-",
                ['U'] = "..-",
                ['V'] = "...-",
                ['W'] = ".--",
                ['X'] = "-..-",
                ['Y'] = "-.--",
                ['Z'] = "--..",
            };

            string[] wordsInMorseCode = Console.ReadLine().Split(" | ");
            StringBuilder message = new StringBuilder();

            for (int i = 0; i < wordsInMorseCode.Length; i++)
            {
                string[] lettersInMorseCode = wordsInMorseCode[i].Split();

                foreach (var letter in lettersInMorseCode)
                {
                    message.Append(morseCodeToCapitalLetters.FirstOrDefault(l => l.Value == letter).Key);
                }
                
                message.Append(' ');
            }

            Console.WriteLine(message);
        }
    }
}
