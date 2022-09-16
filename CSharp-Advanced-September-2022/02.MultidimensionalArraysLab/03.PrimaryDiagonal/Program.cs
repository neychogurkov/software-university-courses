using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            GetMatrixData(matrix);

            int primaryDiagonalSum = GetPrimaryDiagonalSum(matrix);
            Console.WriteLine(primaryDiagonalSum);
            
        }

        static void GetMatrixData(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }
        }

        static int GetPrimaryDiagonalSum(int[,] matrix)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }
    }
}
