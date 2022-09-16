using System;
using System.Linq;

namespace _04.SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            GetMatrixData(matrix);

            char symbolToLookFor = char.Parse(Console.ReadLine());

            if (!ContainsSymbol(matrix, symbolToLookFor))
            {
                Console.WriteLine($"{symbolToLookFor} does not occur in the matrix");
            }
        }

        static void GetMatrixData(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }

        static bool ContainsSymbol(char[,] matrix, char symbolToLookFor)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbolToLookFor)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
