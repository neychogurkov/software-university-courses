using System;

namespace _02.PawnWars
{
    internal class Program
    {
        private const int BoardSize = 8;

        static void Main(string[] args)
        {

            char[,] board = GetBoardData();
            (int whitePawnRow, int whitePawnCol) = GetPawnPosition(board, 'w');
            (int blackPawnRow, int blackPawnCol) = GetPawnPosition(board, 'b');

            int turnCounter = 0;

            while (true)
            {
                string result = MovePawns(board, ref whitePawnRow, whitePawnCol, ref blackPawnRow, blackPawnCol, turnCounter);

                if (result != null)
                {
                    Console.WriteLine(result);
                    return;
                }

                turnCounter++;
            }
        }

        static string MovePawns(char[,] board, ref int whitePawnRow, int whitePawnCol, ref int blackPawnRow, int blackPawnCol, int turnCounter)
        {
            if (turnCounter % 2 == 0)
            {
                board[whitePawnRow--, whitePawnCol] = '-';
                board[whitePawnRow, whitePawnCol] = 'w';

                if ((whitePawnCol > 0 && board[whitePawnRow, whitePawnCol - 1] == 'b') || (whitePawnCol < BoardSize - 1 && board[whitePawnRow, whitePawnCol + 1] == 'b'))
                {
                    return $"Game over! White capture on {(char)(blackPawnCol + 'a')}{BoardSize - blackPawnRow}.";
                }

                if (whitePawnRow == 0)
                {
                    return $"Game over! White pawn is promoted to a queen at {(char)(whitePawnCol + 'a')}{BoardSize - whitePawnRow}.";
                }
            }
            else
            {
                board[blackPawnRow++, blackPawnCol] = '-';
                board[blackPawnRow, blackPawnCol] = 'b';

                if ((blackPawnCol > 0 && board[blackPawnRow, blackPawnCol - 1] == 'w') || (blackPawnCol < BoardSize - 1 && board[blackPawnRow, blackPawnCol + 1] == 'w'))
                {
                    return $"Game over! Black capture on {(char)(whitePawnCol + 'a')}{BoardSize - whitePawnRow}.";
                }

                if (blackPawnRow == BoardSize - 1)
                {
                    return $"Game over! Black pawn is promoted to a queen at {(char)(blackPawnCol + 'a')}{BoardSize - blackPawnRow}.";
                }
            }

            return null;
        }

        static char[,] GetBoardData()
        {
            char[,] board = new char[BoardSize, BoardSize];

            for (int row = 0; row < BoardSize; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < BoardSize; col++)
                {
                    board[row, col] = line[col];
                }
            }

            return board;
        }

        static (int, int) GetPawnPosition(char[,] board, char color)
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
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
