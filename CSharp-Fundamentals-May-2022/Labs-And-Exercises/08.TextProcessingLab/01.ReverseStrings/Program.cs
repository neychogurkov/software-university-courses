using System;
using System.Linq;
using System.Text;

namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (word!="end")
            {
                StringBuilder reversedWord = new StringBuilder();

                for (int i = word.Length-1; i >=0; i--)
                {
                    reversedWord.Append(word[i]);
                }

                Console.WriteLine($"{word} = {reversedWord}");

                word = Console.ReadLine();
            }
        }
    }
}
