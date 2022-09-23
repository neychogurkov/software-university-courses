namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            Dictionary<string, int> wordsOccurrences = new Dictionary<string, int>();

            using (var reader = new StreamReader(wordsFilePath))
            {
                string[] words = reader.ReadLine().ToLower().Split();

                foreach (var word in words)
                {
                    wordsOccurrences[word] = 0;
                }
            }

            using (var reader = new StreamReader(textFilePath))
            {
                Regex regex = new Regex("[a-z]+");

                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    MatchCollection matches = regex.Matches(line.ToLower());

                    foreach (Match match in matches)
                    {
                        if (wordsOccurrences.ContainsKey(match.Value))
                        {
                            wordsOccurrences[match.Value]++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var (word, occurrences) in wordsOccurrences.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{word} - {occurrences}");
                }
            }
        }
    }
}
