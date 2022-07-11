using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordOccurrences = new Dictionary<string, int>();

            string[] words = Console.ReadLine().Split().Select(w => w.ToLower()).ToArray();

            foreach (var word in words)
            {
                if (!wordOccurrences.ContainsKey(word))
                {
                    wordOccurrences[word] = 0;
                }

                wordOccurrences[word]++;
            }

            foreach (var kvp in wordOccurrences.Where(w => w.Value % 2 != 0))
            {
                Console.Write($"{kvp.Key} ");
            }
        }
    }
}
