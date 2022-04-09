using System;

namespace _05.SuitcasesLoad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double trunkCapacity = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int siutcases = 0;

            while (command != "End")
            {
                double siutcaseSize = double.Parse(command);
                siutcases++;

                if (siutcases % 3 == 0)
                {
                    siutcaseSize += 0.1 * siutcaseSize;
                }

                if (trunkCapacity < siutcaseSize)
                {
                    siutcases--;
                    Console.WriteLine("No more space!");
                    Console.WriteLine($"Statistic: {siutcases} suitcases loaded.");
                    return;
                }

                trunkCapacity -= siutcaseSize;

                command = Console.ReadLine();
            }

            Console.WriteLine("Congratulations! All suitcases are loaded!");
            Console.WriteLine($"Statistic: {siutcases} suitcases loaded.");

        }
    }
}
