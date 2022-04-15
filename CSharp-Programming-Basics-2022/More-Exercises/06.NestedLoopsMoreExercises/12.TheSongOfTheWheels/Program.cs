using System;

namespace _12.TheSongOfTheWheels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int count = 0;
            string password = string.Empty;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (a < b && c > d && a * b + c * d == m)
                            {
                                count++;
                                if (count == 4)
                                {
                                    password = a.ToString() + b.ToString() + c.ToString() + d.ToString();
                                }
                                Console.Write($"{a}{b}{c}{d} ");
                            }
                        }
                    }
                }
            }
            Console.WriteLine();

            if (password!=string.Empty)
            {
                Console.WriteLine($"Password: {password}");
            }
            else
            {
                Console.WriteLine("No!");
            }
        }
    }
}
