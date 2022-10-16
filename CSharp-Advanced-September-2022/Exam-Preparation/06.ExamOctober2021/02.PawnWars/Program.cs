using System;

namespace _02.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int BoardSize = 8;

            char[,] board = GetBoardData(BoardSize);
            (int whitePawnRow, int whitePawnCol) = GetPawnPosition(board, BoardSize, 'w');
            (int blackPawnRow, int blackPawnCol) = GetPawnPosition(board, BoardSize, 'b');

            int turnCounter = 0;

            while (true)
            {
                if (turnCounter % 2 == 0)
                {
                    if ((whitePawnCol > 0 && board[whitePawnRow - 1, whitePawnCol - 1] == 'b') || (whitePawnCol < BoardSize - 1 && board[whitePawnRow - 1, whitePawnCol + 1] == 'b'))
                    {
                        Console.WriteLine($"Game over! White capture on {(char)(blackPawnCol + 'a')}{BoardSize - blackPawnRow}.");
                        return;
                    }
                    else
                    {
                        board[whitePawnRow--, whitePawnCol] = '-';
                        board[whitePawnRow, whitePawnCol] = 'w';
                    }

                    if (whitePawnRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(whitePawnCol + 'a')}{BoardSize - whitePawnRow}.");
                        return;
                    }
                }
                else
                {
                    if ((blackPawnCol > 0 && board[blackPawnRow + 1, blackPawnCol - 1] == 'w') || (blackPawnCol < BoardSize - 1 && board[blackPawnRow + 1, blackPawnCol + 1] == 'w'))
                    {
                        Console.WriteLine($"Game over! Black capture on {(char)(whitePawnCol + 'a')}{BoardSize - whitePawnRow}.");
                        return;
                    }
                    else
                    {
                        board[blackPawnRow++, blackPawnCol] = '-';
                        board[blackPawnRow, blackPawnCol] = 'b';
                    }

                    if (blackPawnRow == BoardSize - 1)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(blackPawnCol + 'a')}{BoardSize - blackPawnRow}.");
                        return;
                    }
                }

                turnCounter++;
            }
        }

        static char[,] GetBoardData(int size)
        {
            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = line[col];
                }
            }

            return board;
        }

        static (int, int) GetPawnPosition(char[,] board, int size, char color)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (board[row, col] == color)
                    {
                        return (row, col);
                    }
                }
            }

            return (0, 0);
        }
    }
}
