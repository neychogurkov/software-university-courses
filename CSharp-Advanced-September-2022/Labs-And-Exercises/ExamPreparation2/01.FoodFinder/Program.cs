using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split().Select(char.Parse));
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split().Select(char.Parse));
            string[] words = new string[] { "pear", "flour", "pork", "olive" };
            HashSet<char> letters = new HashSet<char>();

            while (consonants.Any())
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();
                vowels.Enqueue(currentVowel);

                if (words.Any(w => w.Contains(currentVowel)))
                {
                    letters.Add(currentVowel);
                }
                if (words.Any(w => w.Contains(currentConsonant)))
                {
                    letters.Add(currentConsonant);
                }
            }

            List<string> wordsFound = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                foreach (var letter in letters)
                {
                    if (word.Contains(letter))
                    {
                        word = word.Remove(word.IndexOf(letter), 1);
                    }
                }

                if (word == string.Empty)
                {
                    wordsFound.Add(words[i]);
                }
            }

            Console.WriteLine($"Words found: {wordsFound.Count}");
            Console.WriteLine(string.Join(Environment.NewLine, wordsFound));
        }
    }
}
