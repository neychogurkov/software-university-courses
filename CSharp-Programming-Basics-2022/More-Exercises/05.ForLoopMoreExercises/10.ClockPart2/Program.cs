using System;

namespace _10.ClockPart2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    for (int k = 0; k < 60; k++)
                    {
                    Console.WriteLine($"{i} : {j} : {k}");
                    }
                }
            }
        }
    }
}
