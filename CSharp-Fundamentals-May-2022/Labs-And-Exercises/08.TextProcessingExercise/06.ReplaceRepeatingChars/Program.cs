using System;

namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string sequence = text[0].ToString();

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == text[i + 1])
                {
                    sequence += text[i];

                    if (i == text.Length - 2)
                    {
                        text = text.Replace(sequence, sequence[0].ToString());
                    }
                }
                else
                {
                    text = text.Replace(sequence, sequence[0].ToString());
                    i -= sequence.Length - 1;
                    sequence = text[i + 1].ToString();
                }
            }

            Console.WriteLine(text);
        }
    }
}
