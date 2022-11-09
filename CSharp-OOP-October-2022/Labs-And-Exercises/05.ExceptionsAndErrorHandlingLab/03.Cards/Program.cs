using System;
using System.Collections.Generic;

namespace _03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> validCardFaces = new HashSet<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            Dictionary<string, string> validCardSuits = new Dictionary<string, string>()
            {
                ["S"] = "\u2660",
                ["H"] = "\u2665",
                ["D"] = "\u2666",
                ["C"] = "\u2663",
            };

            string[] cardsInput = Console.ReadLine().Split(", ");

            List<Card> cards = new List<Card>();

            foreach (var cardInput in cardsInput)
            {
                try
                {
                    string[] cardInfo = cardInput.Split();
                    string face = cardInfo[0];
                    string suit = cardInfo[1];

                    if (!validCardFaces.Contains(face) || !validCardSuits.ContainsKey(suit))
                    {
                        throw new ArgumentException("Invalid card!");
                    }

                    Card card = new Card(face, validCardSuits[suit]);
                    cards.Add(card);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(' ', cards));
        }
    }
}
