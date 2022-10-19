using System;

namespace _02.SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int livesCount = int.Parse(Console.ReadLine());
            int rowsCount = int.Parse(Console.ReadLine());
            char[][] maze = GetMazeData(rowsCount);
            (int marioRow, int marioCol) = GetMarioPosition(maze);

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                char direction = char.Parse(command[0]);
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                maze[row][col] = 'B';

                int oldMarioRow = marioRow;
                int oldMarioCol = marioCol;
                maze[marioRow][marioCol] = '-';

                switch (direction)
                {
                    case 'W':
                        marioRow--;
                        break;
                    case 'S':
                        marioRow++;
                        break;
                    case 'A':
                        marioCol--;
                        break;
                    case 'D':
                        marioCol++;
                        break;
                }

                livesCount--;

                if (marioRow >= 0 && marioRow < maze.Length && marioCol >= 0 && marioCol < maze[marioRow].Length)
                {
                    if (maze[marioRow][marioCol] == 'B')
                    {
                        livesCount -= 2;
                    }
                    else if (maze[marioRow][marioCol] == 'P')
                    {
                        maze[marioRow][marioCol] = '-';
                        Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesCount}");
                        break;
                    }
                }
                else
                {
                    marioRow = oldMarioRow;
                    marioCol = oldMarioCol;
                }

                if (livesCount <= 0)
                {
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    maze[marioRow][marioCol] = 'X';
                    break;
                }
            }

            PrintMaze(maze);
        }

        static char[][] GetMazeData(int rowsCount)
        {
            char[][] maze = new char[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                maze[row] = Console.ReadLine().ToCharArray();
            }

            return maze;
        }

        static (int, int) GetMarioPosition(char[][] maze)
        {
            for (int row = 0; row < maze.Length; row++)
            {
                for (int col = 0; col < maze[row].Length; col++)
                {
                    if (maze[row][col] == 'M')
                    {
                        return (row, col);
                    }
                }
            }

            return (0, 0);
        }

        static void PrintMaze(char[][] maze)
        {
            foreach (var row in maze)
            {
                Console.WriteLine(row);
            }
        }
    }
}
