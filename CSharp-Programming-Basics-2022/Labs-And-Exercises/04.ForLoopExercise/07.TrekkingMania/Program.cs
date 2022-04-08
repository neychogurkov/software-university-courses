using System;

namespace _07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            double musalaClimbers = 0;
            double montBlancClimbers = 0;
            double kilimanjaroClimbers = 0;
            double k2Climbers = 0;
            double everestClimbers = 0;
            double totalClimbers = 0;
            for (int i = 0; i < groups; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());
                totalClimbers += peopleInGroup;
                if (peopleInGroup <= 5)
                {
                    musalaClimbers += peopleInGroup;
                }
                else if (peopleInGroup >= 6 && peopleInGroup <= 12)
                {
                    montBlancClimbers += peopleInGroup;
                }
                else if (peopleInGroup >= 13 && peopleInGroup <= 25)
                {
                    kilimanjaroClimbers += peopleInGroup;
                }
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                {
                    k2Climbers += peopleInGroup;
                }
                else
                {
                    everestClimbers += peopleInGroup;
                }
            }
            musalaClimbers = musalaClimbers / totalClimbers * 100;
            montBlancClimbers = montBlancClimbers / totalClimbers * 100;
            kilimanjaroClimbers = kilimanjaroClimbers / totalClimbers * 100;
            k2Climbers = k2Climbers / totalClimbers * 100;
            everestClimbers = everestClimbers / totalClimbers * 100;
            Console.WriteLine($"{musalaClimbers:f2}%");
            Console.WriteLine($"{montBlancClimbers:f2}%");
            Console.WriteLine($"{kilimanjaroClimbers:f2}%");
            Console.WriteLine($"{k2Climbers:f2}%");
            Console.WriteLine($"{everestClimbers:f2}%");
        }
    }
}
