﻿namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = lines[i].Count(char.IsLetter);
                int punctuationMarksCount = lines[i].Count(char.IsPunctuation);

                lines[i] = $"Line {i + 1}: {lines[i]} ({lettersCount})({punctuationMarksCount})";
            }

            File.WriteAllLines(outputFilePath, lines);
        }
    }
}
