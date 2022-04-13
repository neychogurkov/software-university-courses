using System;
using System.Collections.Generic;

namespace _03.StreamOfLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<char> list = new List<char>();
            string word = string.Empty;
            
            while (command != "End")
            {
                char symbol = char.Parse(command);

                if ((symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z'))
                {
                    if (symbol == 'c' && !list.Contains(symbol))
                    {
                        list.Add(symbol);
                    }
                    else if (symbol == 'o' && !list.Contains(symbol))
                    {
                        list.Add(symbol);
                    }
                    else if (symbol == 'n' && !list.Contains(symbol))
                    {
                        list.Add(symbol);
                    }
                    else
                    word += symbol;

                    if (list.Contains('c')&& list.Contains('o')&& list.Contains('n'))
                    {
                        Console.Write(word + " ");
                        word = string.Empty;
                        list = new List<char>();
                    }
                }

                command = Console.ReadLine();
            }

        }
    }
}
