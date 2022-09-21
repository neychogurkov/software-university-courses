using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char,int> symbolsOccurrences = new SortedDictionary<char,int>();

            string text = Console.ReadLine();

            foreach (var symbol in text)
            {
                if (!symbolsOccurrences.ContainsKey(symbol))
                {
                    symbolsOccurrences[symbol] = 0;
                }

                symbolsOccurrences[symbol]++;
            }

            foreach (var (symbol, occurrences) in symbolsOccurrences)
            {
                Console.WriteLine($"{symbol}: {occurrences} time/s");
            }
        }
    }
}
