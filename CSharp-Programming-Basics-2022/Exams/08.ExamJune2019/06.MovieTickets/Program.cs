using System;

namespace _06.MovieTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            for (int i = a1; i <= a2 - 1; i++)
            {
                char firstSymbol = (char)i;

                for (int j = 1; j <= n - 1; j++)
                {
                    int secondSymbol = j;

                    for (int z = 1; z <= n / 2 - 1; z++)
                    {
                        int thirdSymbol = z;
                        int fourthSymbol = i;

                        if (firstSymbol % 2 != 0 && (secondSymbol + thirdSymbol + fourthSymbol) % 2 != 0)
                        {
                            Console.WriteLine($"{firstSymbol}-{secondSymbol}{thirdSymbol}{fourthSymbol}");
                        }
                    }
                }

            }
        }
    }
}
