using System;

namespace _07.FootballLeague
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            int fans = int.Parse(Console.ReadLine());
            int fansInSectorA = 0;
            int fansInSectorB = 0;
            int fansInSectorV = 0;
            int fansInSectorG = 0;

            for (int i = 0; i < fans; i++)
            {
                char sector = char.Parse(Console.ReadLine());

                if (sector == 'A')
                {
                    fansInSectorA++;
                }
                else if (sector == 'B')
                {
                    fansInSectorB++;
                }
                else if (sector == 'V')
                {
                    fansInSectorV++;
                }
                else if (sector == 'G')
                {
                    fansInSectorG++;
                }
            }

            Console.WriteLine($"{(double)fansInSectorA / fans * 100:f2}%");
            Console.WriteLine($"{(double)fansInSectorB / fans * 100:f2}%");
            Console.WriteLine($"{(double)fansInSectorV / fans * 100:f2}%");
            Console.WriteLine($"{(double)fansInSectorG / fans * 100:f2}%");
            Console.WriteLine($"{(double)fans / capacity * 100:f2}%");
        }
    }
}
