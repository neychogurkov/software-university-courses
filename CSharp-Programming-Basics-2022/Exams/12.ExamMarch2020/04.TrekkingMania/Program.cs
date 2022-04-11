using System;

namespace _04.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int groups = int.Parse(Console.ReadLine());
            double musalaClimbers = 0;
            double montblancClimbers = 0;
            double kilimanjaroClimbers = 0;
            double k2Climbers = 0;
            double everestClimbers = 0;
            double totalPeople = 0;

            for (int i = 0; i < groups; i++)
            {
                int people = int.Parse(Console.ReadLine());
                totalPeople += people;
                if (people <= 5)
                {
                    musalaClimbers += people;
                }
                else if (people <= 12)
                {
                    montblancClimbers += people;
                }
                else if (people <= 25)
                {
                    kilimanjaroClimbers += people;
                }
                else if (people <= 40)
                {
                    k2Climbers += people;
                }
                else
                {
                    everestClimbers += people;
                }
            }

            Console.WriteLine($"{musalaClimbers / totalPeople * 100:f2}%");
            Console.WriteLine($"{montblancClimbers / totalPeople * 100:f2}%");
            Console.WriteLine($"{kilimanjaroClimbers / totalPeople * 100:f2}%");
            Console.WriteLine($"{k2Climbers / totalPeople * 100:f2}%");
            Console.WriteLine($"{everestClimbers / totalPeople * 100:f2}%");
        }
    }
}
