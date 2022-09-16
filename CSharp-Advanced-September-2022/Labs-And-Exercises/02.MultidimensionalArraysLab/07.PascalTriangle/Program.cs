using System;

namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[size][];

            GeneratePascalTriangle(pascalTriangle);

            PrintPascalTriangle(pascalTriangle);
        }

        static void GeneratePascalTriangle(long[][] pascalTriangle)
        {
            for (int row = 0; row < pascalTriangle.Length; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                pascalTriangle[row][0] = 1;
                pascalTriangle[row][pascalTriangle[row].Length - 1] = 1;

                for (int col = 1; col < pascalTriangle[row].Length - 1; col++)
                {
                    pascalTriangle[row][col] = pascalTriangle[row - 1][col - 1] + pascalTriangle[row - 1][col];
                }
            }
        }

        static void PrintPascalTriangle(long[][] pascalTriangle)
        {
            foreach (var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
