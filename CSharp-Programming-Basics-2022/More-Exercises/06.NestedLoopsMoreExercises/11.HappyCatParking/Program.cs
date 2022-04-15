using System;

namespace _11.HappyCatParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double totalFee = 0;

            for (int i = 1; i <= days; i++)
            {
                double dailyFee = 0;

                for (int j = 1; j <= hours; j++)
                {
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        dailyFee += 2.5;
                    }
                    else if (i % 2 != 0 && j % 2 == 0)
                    {
                        dailyFee += 1.25;
                    }
                    else
                    {
                        dailyFee += 1;
                    }
                }
                totalFee += dailyFee;

                Console.WriteLine($"Day: {i} - {dailyFee:f2} leva");
            }

            Console.WriteLine($"Total: {totalFee:f2} leva");
        }
    }
}
