using System;

namespace _06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int pieces = width * length;
            string input = Console.ReadLine();

            while (input != "STOP")
            {
                int piecesTaken = int.Parse(input);
                pieces -= piecesTaken;
                if (pieces < 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(pieces)} pieces more.");
                    return;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{pieces} pieces are left.");
        }
    }
}
