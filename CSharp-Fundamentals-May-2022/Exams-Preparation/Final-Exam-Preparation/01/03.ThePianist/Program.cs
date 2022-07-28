using System;
using System.Collections.Generic;

namespace _03.ThePianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();
            List<string> piecesNames = new List<string>();

            int countOfPieces = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfPieces; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split('|');

                string piece = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];

                pieces[piece] = new Piece(composer, key);
                piecesNames.Add(piece);
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
                        AddPiece(command, pieces, piece, piecesNames);
                        break;
                    case "Remove":
                        RemovePiece(pieces, piece, piecesNames);
                        break;
                    case "ChangeKey":
                        ChangeKey(command, pieces, piece);
                        break;
                }
            }

            foreach (var piece in piecesNames)
            {
                Console.WriteLine($"{piece} -> Composer: {pieces[piece].Composer}, Key: {pieces[piece].Key}");
            }
        }

        static void ChangeKey(string[] command, Dictionary<string, Piece> pieces, string piece)
        {
            string newKey = command[2];

            if (pieces.ContainsKey(piece))
            {
                pieces[piece].Key = newKey;
                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }

        static void RemovePiece(Dictionary<string, Piece> pieces, string piece, List<string> piecesNames)
        {
            if (pieces.ContainsKey(piece))
            {
                piecesNames.Remove(piece);
                pieces.Remove(piece);
                Console.WriteLine($"Successfully removed {piece}!");
            }
            else
            {
                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
            }
        }

        static void AddPiece(string[] command, Dictionary<string, Piece> pieces, string piece, List<string> piecesNames)
        {
            string composer = command[2];
            string key = command[3];

            if (pieces.ContainsKey(piece))
            {
                Console.WriteLine($"{piece} is already in the collection!");
            }
            else
            {
                piecesNames.Add(piece);
                pieces[piece] = new Piece(composer, key);
                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
            }
        }
    }

    class Piece
    {
        public string Composer { get; set; }
        public string Key { get; set; }

        public Piece(string composer, string key)
        {
            Composer = composer;
            Key = key;
        }
    }
}