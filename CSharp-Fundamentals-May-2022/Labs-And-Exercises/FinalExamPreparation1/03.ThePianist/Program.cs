using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, KeyValuePair<string, string>> pieces =
                new Dictionary<string, KeyValuePair<string, string>>();
            List<string> namesOfPieces = new List<string>();

            int countOfPieces = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPieces; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split('|');

                string piece = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];

                pieces[piece] = new KeyValuePair<string, string>(composer, key);
                namesOfPieces.Add(piece);
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split('|');

                if (command[0] == "Stop")
                {
                    break;
                }

                string piece = command[1];

                switch (command[0])
                {
                    case "Add":
                        string composer = command[2];
                        string key = command[3];
                        AddPiece(pieces, piece, namesOfPieces, composer, key);
                        break;
                    case "Remove":
                        RemovePiece(pieces, piece, namesOfPieces);
                        break;
                    case "ChangeKey":
                        string newKey = command[2];
                        ChangeKey(pieces, piece, newKey);
                        break;
                }
            }

            foreach (var name in namesOfPieces)
            {
                Console.WriteLine($"{name} -> Composer: {pieces[name].Key}, Key: {pieces[name].Value}");
            }
        }

        static void ChangeKey(Dictionary<string, KeyValuePair<string, string>> pieces, string piece, string newKey)
        {
            if (pieces.ContainsKey(piece))
            {
                pieces[piece] = new KeyValuePair<string, string>(pieces[piece].Key, newKey);
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }

        static void RemovePiece(Dictionary<string, KeyValuePair<string, string>> pieces, string piece, List<string> namesOfPieces)
        {
            if (pieces.ContainsKey(piece))
            {
                namesOfPieces.Remove(piece);
                pieces.Remove(piece);
                Console.WriteLine($"Successfully removed {piece}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }

        static void AddPiece(Dictionary<string, KeyValuePair<string, string>> pieces, string piece, List<string> namesOfPieces, string composer, string key)
        {
            if (pieces.ContainsKey(piece))
            {
                Console.WriteLine($"{piece} is already in the collection!");
            }
            else
            {
                namesOfPieces.Add(piece);
                pieces[piece] = new KeyValuePair<string, string>(composer, key);
                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
            }
        }
    }
}
