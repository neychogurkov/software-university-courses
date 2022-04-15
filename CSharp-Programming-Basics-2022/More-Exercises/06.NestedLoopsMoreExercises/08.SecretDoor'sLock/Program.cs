using System;

namespace _08.SecretDoor_sLock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxHundreds = int.Parse(Console.ReadLine());
            int maxTens = int.Parse(Console.ReadLine());
            int maxOnes = int.Parse(Console.ReadLine());

            for (int i = 1; i <= maxHundreds; i++)
            {
                for (int j = 1; j <= maxTens; j++)
                {
                    for (int k = 1; k <= maxOnes; k++)
                    {
                        if (i % 2 == 0 && k % 2 == 0 && (j == 2 || j == 3 || j == 5 | j == 7))
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}
