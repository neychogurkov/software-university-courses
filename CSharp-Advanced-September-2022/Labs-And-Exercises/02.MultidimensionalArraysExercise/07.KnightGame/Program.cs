using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] board = new char[size, size];
            GetBoardData(board);

            int removedKnights = 0;

            List<Knight> knights = new List<Knight>();

            while (true)
            {
                FindKnights(board, knights);

                foreach (var knight in knights)
                {
                    int row = knight.Row;
                    int col = knight.Col;

                    AttackKnight(board, knights, row - 2, col - 1);
                    AttackKnight(board, knights, row - 2, col + 1);
                    AttackKnight(board, knights, row - 1, col - 2);
                    AttackKnight(board, knights, row - 1, col + 2);
                    AttackKnight(board, knights, row + 1, col - 2);
                    AttackKnight(board, knights, row + 1, col + 2);
                    AttackKnight(board, knights, row + 2, col - 1);
                    AttackKnight(board, knights, row + 2, col + 1);
                }


                if (knights.Max(k => k.CountOfPossibleAttacks) == 0)
                {
                    break;
                }

                removedKnights = RemoveKnight(board, removedKnights, knights);

                knights.Clear();
            }

            Console.WriteLine(removedKnights);
        }

        static void GetBoardData(char[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < board.GetLength(0); col++)
                {
                    board[row, col] = line[col];
                }
            }
        }

        static void FindKnights(char[,] board, List<Knight> knights)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(0); col++)
                {
                    if (board[row, col] == 'K')
                    {
                        Knight knight = new Knight(row, col);
                        knights.Add(knight);
                    }
                }
            }
        }

        static void AttackKnight(char[,] board, List<Knight> knights, int row, int col)
        {
            if (row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(0) && board[row, col] == 'K')
            {
                knights.First(k => k.Row == row && k.Col == col).CountOfPossibleAttacks++;
            }
        }

        static int RemoveKnight(char[,] board, int removedKnights, List<Knight> knights)
        {
            Knight knightToRemove = knights.First(k => k.CountOfPossibleAttacks == knights.Max(knight => knight.CountOfPossibleAttacks));

            board[knightToRemove.Row, knightToRemove.Col] = '0';

            return ++removedKnights;
        }
    }

    class Knight
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int CountOfPossibleAttacks { get; set; }

        public Knight(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }

}
