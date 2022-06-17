using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondPlayerDeck = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < firstPlayerDeck.Count; i++)
            {
                if (firstPlayerDeck[i] > secondPlayerDeck[i])
                {
                    firstPlayerDeck.Add(firstPlayerDeck[i]);
                    firstPlayerDeck.Add(secondPlayerDeck[i]);
                }
                else if (secondPlayerDeck[i] > firstPlayerDeck[i])
                {
                    secondPlayerDeck.Add(secondPlayerDeck[i]);
                    secondPlayerDeck.Add(firstPlayerDeck[i]);
                }

                firstPlayerDeck.Remove(firstPlayerDeck[i]);
                secondPlayerDeck.Remove(secondPlayerDeck[i]);


                i--;

                if (firstPlayerDeck.Count == 0 || secondPlayerDeck.Count == 0)
                {
                    break;
                }
            }

            if (firstPlayerDeck.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerDeck.Sum()}");
            }
            else if (secondPlayerDeck.Count == 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerDeck.Sum()}");
            }
        }
    }
}
