using System;

namespace _02.LettersCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char letter = char.Parse(Console.ReadLine());
            int validCombinations = 0;

            for(char i = start; i <= end; i++)
            {
                for (char j = start; j <= end; j++)
                {
                    for (char k = start; k <= end; k++)
                    {
                        if (i != letter && j != letter && k != letter)
                        {
                            validCombinations++;
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }

            Console.WriteLine(validCombinations);
        }
    }
}
