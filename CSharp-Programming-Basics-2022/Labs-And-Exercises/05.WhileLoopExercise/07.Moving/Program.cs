using System;

namespace _07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int freeSpace = width * length * height;
            string command = Console.ReadLine();

            while (command != "Done")
            {
                int boxes = int.Parse(command);
                freeSpace -= boxes;
                if (freeSpace < 0)
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(freeSpace)} Cubic meters more.");
                    return;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{freeSpace} Cubic meters left.");
        }
    }
}
