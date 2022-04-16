using System;

namespace _05.SquareFrame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == n - 1)
                {
                    Console.Write("+ ");
                }
                else
                {
                    Console.Write("- ");
                }
            }
            Console.WriteLine();

            for (int i = 0; i < n-2; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0 || j == n - 1)
                    {
                        Console.Write("| ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < n; i++)
            {
                if (i == 0 || i == n - 1)
                {
                    Console.Write("+ ");
                }
                else
                {
                    Console.Write("- ");
                }
            }
        }
    }
}
