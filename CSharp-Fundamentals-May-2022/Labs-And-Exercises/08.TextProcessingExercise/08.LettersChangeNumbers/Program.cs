using System;

namespace _08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            decimal totalSum = 0;

            foreach (var word in words)
            {
                char frontLetter = word[0];
                char backLetter = word[word.Length - 1];

                decimal number = int.Parse(word.Substring(1, word.Length - 2));

                int frontLetterPosition = char.Parse(frontLetter.ToString().ToLower()) - 'a' + 1;
                int backLetterPosition = char.Parse(backLetter.ToString().ToLower()) - 'a' + 1;

                if (char.IsUpper(frontLetter))
                {
                    number /= frontLetterPosition;
                }
                else
                {
                    number *= frontLetterPosition;
                }

                if (char.IsUpper(backLetter))
                {
                    number -= backLetterPosition;
                }
                else
                {
                    number += backLetterPosition;
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
