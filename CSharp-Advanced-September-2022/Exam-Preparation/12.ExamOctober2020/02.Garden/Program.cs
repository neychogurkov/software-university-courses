using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rowsCount = dimensions[0];
            int colsCount = dimensions[1];
            int[,] garden = new int[rowsCount, colsCount];

            List<(int, int)> flowersCoordinates = new List<(int, int)>();

            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int row = int.Parse(command.Split()[0]);
                int col = int.Parse(command.Split()[1]);

                if (row < 0 || row >= rowsCount || col < 0 || col >= colsCount)
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                garden[row, col] = 1;
                flowersCoordinates.Add((row, col));
            }

            foreach (var flowerCoordinates in flowersCoordinates)
            {
                int row = flowerCoordinates.Item1;
                int col = flowerCoordinates.Item2;

                BloomFlower(garden, row, col);
            }

            PrintGarden(garden);
        }

        private static void BloomFlower(int[,] garden, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                garden[i, col]++;
            }
            for (int i = row + 1; i < garden.GetLength(0); i++)
            {
                garden[i, col]++;
            }
            for (int i = 0; i < col; i++)
            {
                garden[row, i]++;
            }
            for (int i = col + 1; i < garden.GetLength(1); i++)
            {
                garden[row, i]++;
            }
        }

        private static void PrintGarden(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
