using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split().ToList();
            List<string> randomizedWords = new List<string>();
            Random rnd = new Random();

            while (words.Count > 0)
            {
                int index = rnd.Next(words.Count);
                randomizedWords.Add(words[index]);
                words.RemoveAt(index);
            }

            Console.WriteLine(string.Join(Environment.NewLine, randomizedWords));
        }
    }
}
