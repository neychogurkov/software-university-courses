using System;

namespace _13.PrimePairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstPairStart = int.Parse(Console.ReadLine());
            int secondPairStart = int.Parse(Console.ReadLine());
            int firstPairEnd = int.Parse(Console.ReadLine()) + firstPairStart;
            int secondPairEnd = int.Parse(Console.ReadLine()) + secondPairStart;

            for (int i = firstPairStart; i <= firstPairEnd; i++)
            {
                for (int j = secondPairStart; j <= secondPairEnd; j++)
                {
                    bool isPrime = true;

                    for (int k = 2; k < i; k++)
                    {
                        if (i % k == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    for (int k = 2; k < j; k++)
                    {
                        if (j % k == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                    {
                        Console.WriteLine($"{i}{j}");
                    }
                }
            }
        }
    }
}
