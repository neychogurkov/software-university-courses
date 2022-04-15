using System;

namespace _01.UniquePINCodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            for(int i = 1; i <= firstNumber; i++)
            {
                for(int j= 1; j <= secondNumber; j++)
                {
                    for(int k = 1; k <= thirdNumber; k++)
                    {
                        if (i % 2 == 0 && k % 2 == 0 && (j == 2 || j == 3 || j == 5 || j == 7))
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}
