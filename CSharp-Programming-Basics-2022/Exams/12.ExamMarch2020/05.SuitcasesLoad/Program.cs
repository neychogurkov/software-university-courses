using System;

namespace _05.SuitcasesLoad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double capacity = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int suitcaseCount = 0;

            while (command != "End")
            {
                double suitcaseSize = double.Parse(command);
                suitcaseCount++;

                if (suitcaseCount % 3 == 0)
                {
                    suitcaseSize += 0.1 * suitcaseSize;
                }

                if (suitcaseSize > capacity)
                {
                    suitcaseCount--;
                    Console.WriteLine("No more space!");
                    Console.WriteLine($"Statistic: {suitcaseCount} suitcases loaded.");
                    return;
                }

                capacity -= suitcaseSize;

                command = Console.ReadLine();
            }

            Console.WriteLine("Congratulations! All suitcases are loaded!");
            Console.WriteLine($"Statistic: {suitcaseCount} suitcases loaded.");
        }
    }
}
