using System;

namespace _10.Profit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int oneLevCoins = int.Parse(Console.ReadLine());
            int twoLevsCoins = int.Parse(Console.ReadLine());
            int fiveLevsNotes = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i <= oneLevCoins; i++)
            {
                for (int j = 0; j <= twoLevsCoins; j++)
                {
                    for (int k = 0; k <= fiveLevsNotes; k++)
                    {
                        if (i * 1 + j * 2 + k * 5 == sum)
                        {
                            Console.WriteLine($"{i} * 1 lv. + {j} * 2 lv. + {k} * 5 lv. = {sum} lv.");
                        }
                    }
                }
            }
        }
    }
}
