using System;

namespace _03.Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loadsCount = int.Parse(Console.ReadLine());
            double minibusPercentage = 0;
            double truckPercentage = 0;
            double trainPercentage = 0;
            int totalTonnage = 0;
            double totalPrice = 0;

            for (int i = 0; i < loadsCount; i++)
            {
                int tonnage = int.Parse(Console.ReadLine());
                totalTonnage += tonnage;

                if (tonnage <= 3)
                {
                    minibusPercentage += tonnage;
                    totalPrice += 200 * tonnage;
                }
                else if (tonnage <= 11)
                {
                    truckPercentage += tonnage;
                    totalPrice += 175 * tonnage;
                }
                else
                {
                    trainPercentage += tonnage;
                    totalPrice += 120 * tonnage;
                }
            }

            Console.WriteLine($"{totalPrice / totalTonnage:f2}");
            Console.WriteLine($"{minibusPercentage / totalTonnage * 100:f2}%");
            Console.WriteLine($"{truckPercentage / totalTonnage * 100:f2}%");
            Console.WriteLine($"{trainPercentage / totalTonnage * 100:f2}%");
        }
    }
}
