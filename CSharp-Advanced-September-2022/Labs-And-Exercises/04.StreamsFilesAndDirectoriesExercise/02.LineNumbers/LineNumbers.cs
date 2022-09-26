namespace LineNumbers
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
                int punctuationMarksCount = lines[i].Count(ch => ch == '.' || ch == ',' || ch == '!' || ch == '?' || ch == ':' || ch == ';' || ch == '-' || ch == '\'' || ch == '\"');

                lines[i] = $"Line {i + 1}: -I was quick to judge him, but it wasn't his fault. ({lettersCount})({punctuationMarksCount})";
            }

            File.WriteAllLines(outputFilePath, lines);
        }
    }
}
