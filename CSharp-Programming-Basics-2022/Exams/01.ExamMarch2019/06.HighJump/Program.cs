using System;

namespace _06.HighJump
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goalHeight = int.Parse(Console.ReadLine());
            int currentHeight = goalHeight - 30;
            int unsuccessfulJumps = 0;
            int jumpsCount = 0;

            while (currentHeight<=goalHeight)
            {
                int jumpHeight = int.Parse(Console.ReadLine());
                jumpsCount++;

                if (jumpHeight > currentHeight)
                {
                    currentHeight += 5;
                    unsuccessfulJumps = 0;
                }
                else
                {
                    unsuccessfulJumps++;
                }

                if (unsuccessfulJumps == 3)
                {
                    Console.WriteLine($"Tihomir failed at {currentHeight}cm after {jumpsCount} jumps.");
                    return;
                }
            }

            Console.WriteLine($"Tihomir succeeded, he jumped over {goalHeight}cm after {jumpsCount} jumps.");
        }
    }
}
