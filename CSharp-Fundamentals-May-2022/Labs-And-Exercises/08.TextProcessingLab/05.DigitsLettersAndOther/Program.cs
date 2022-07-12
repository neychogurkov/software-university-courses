using System;
using System.Text;

namespace _05.DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder otherCharacters = new StringBuilder();

            foreach (var character in text)
            {
                if (Char.IsDigit(character))
                {
                    digits.Append(character);
                }
                else if (Char.IsLetter(character))
                {
                    letters.Append(character);
                }
                else
                {
                    otherCharacters.Append(character);
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(otherCharacters);
        }
    }
}
