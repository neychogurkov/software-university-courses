using System;

namespace _04.MakeItRain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int tCount = 0;
            int fCount = 0;

            for (int i = 0; i < n; i++)
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int c = int.Parse(Console.ReadLine());

                if (b != 0)
                {
                    if (a / b == c)
                    {
                        tCount += 'T';
                        fCount /= 'T' / 10;
                        continue;
                    }
                }

                fCount += 'F';
                tCount /= 'F' / 10;
            }

            Console.WriteLine($"T: {tCount}");
            Console.WriteLine($"F: {fCount}");

            if (fCount != 0)
            {
                Console.WriteLine($"Got a Roin coin: {tCount / fCount % 2 == 0} ");
            }
            else
            {
                Console.WriteLine($"Got a Roin coin: {false} ");
            }
        }
    }
}
