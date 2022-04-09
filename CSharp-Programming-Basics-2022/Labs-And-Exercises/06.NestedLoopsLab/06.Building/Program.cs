using System;

namespace _06.Building
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int roomsPerFloor = int.Parse(Console.ReadLine());

            for (int i = floors; i > 0; i--)
            {
                for (int j = 0; j < roomsPerFloor; j++)
                {
                    if (i == floors)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write($"O{i}{j} ");
                        }
                        else
                        {
                            Console.Write($"A{i}{j} ");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
