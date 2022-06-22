using System;

namespace _01.SoftUniReception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int totalEfficiencyPerHour = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;
            int studentsCount = int.Parse(Console.ReadLine());
            int timeNeeded = 0;
            int hour = 0;

            while (studentsCount > 0)
            {
                hour++;
                timeNeeded++;

                if (hour % 4 != 0)
                {
                    studentsCount -= totalEfficiencyPerHour;
                }
            }

            Console.WriteLine($"Time needed: {timeNeeded}h.");
        }
    }
}
