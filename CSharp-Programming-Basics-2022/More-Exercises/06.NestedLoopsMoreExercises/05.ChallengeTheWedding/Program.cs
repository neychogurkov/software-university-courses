using System;

namespace _05.ChallengeTheWedding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int freeTables = int.Parse(Console.ReadLine());

            for (int j = 1; j <= men; j++)
            {
                for (int k = 1; k <= women; k++)
                {
                    Console.Write($"({j} <-> {k}) ");
                    freeTables--;

                    if (freeTables == 0)
                    {
                        return;
                    }
                }
            }

        }
    }
}
