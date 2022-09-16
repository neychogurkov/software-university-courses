using System;
using System.Linq;
using System.Numerics;

namespace _06.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rowsCount][];

            GetJaggedArrayData(jagged);

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "END")
                {
                    break;
                }

                ExecuteCommands(jagged, command);
            }

            PrintJaggedArray(jagged);
        }

        static void GetJaggedArrayData(int[][] jagged)
        {
            for (int row = 0; row < jagged.Length; row++)
            {
                jagged[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
        }

        static void ExecuteCommands(int[][] jagged, string[] command)
        {
            int row = int.Parse(command[1]);
            int col = int.Parse(command[2]);
            int value = int.Parse(command[3]);

            if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
            {
                if (command[0] == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (command[0] == "Subtract")
                {
                    jagged[row][col] -= value;
                }
            }
            else
            {
                Console.WriteLine("Invalid coordinates");
            }
        }

        static void PrintJaggedArray(int[][] jagged)
        {
            foreach (var row in jagged)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
