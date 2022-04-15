using System;

namespace _05.GameOfIntervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int moves = int.Parse(Console.ReadLine());
            double result = 0;
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            double invalidNumbersPercentage = 0;

            for (int i = 0; i < moves; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number >= 0 && number <= 9)
                {
                    result += 0.2 * number;
                    p1++;
                }
                else if (number >= 10 && number <= 19)
                {
                    result += 0.3 * number;
                    p2++;
                }
                else if (number >= 20 && number <= 29)
                {
                    result += 0.4 * number;
                    p3++;
                }
                else if (number >= 30 && number <= 39)
                {
                    result += 50;
                    p4++;
                }
                else if (number >= 40 && number <= 50)
                {
                    result += 100;
                    p5++;
                }
                else
                {
                    result /= 2;
                    invalidNumbersPercentage++;
                }
            }

            Console.WriteLine($"{result:f2}");
            Console.WriteLine($"From 0 to 9: {p1 / moves * 100:f2}%");
            Console.WriteLine($"From 10 to 19: {p2 / moves * 100:f2}%");
            Console.WriteLine($"From 20 to 29: {p3 / moves * 100:f2}%");
            Console.WriteLine($"From 30 to 39: {p4 / moves * 100:f2}%");
            Console.WriteLine($"From 40 to 50: {p5 / moves * 100:f2}%");
            Console.WriteLine($"Invalid numbers: {invalidNumbersPercentage/moves*100:f2}%");
        }
    }
}
