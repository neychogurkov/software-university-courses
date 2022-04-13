using System;

namespace _06.TruckDriver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            int kilometersPerMonth = int.Parse(Console.ReadLine());
            double salary = 0;

            if (season == "Spring" || season == "Autumn")
            {
                if (kilometersPerMonth <= 5000)
                {
                    salary = 0.75 * kilometersPerMonth;
                }
                else if (kilometersPerMonth <= 10000)
                {
                    salary = 0.95 * kilometersPerMonth;
                }
                else if (kilometersPerMonth <= 20000)
                {
                    salary = 1.45 * kilometersPerMonth;
                }
            }
            else if (season == "Summer")
            {
                if (kilometersPerMonth <= 5000)
                {
                    salary = 0.9 * kilometersPerMonth;
                }
                else if (kilometersPerMonth <= 10000)
                {
                    salary = 1.1 * kilometersPerMonth;
                }
                else if (kilometersPerMonth <= 20000)
                {
                    salary = 1.45 * kilometersPerMonth;
                }
            }
            else if (season == "Winter")
            {
                if (kilometersPerMonth <= 5000)
                {
                    salary = 1.05 * kilometersPerMonth;
                }
                else if (kilometersPerMonth <= 10000)
                {
                    salary = 1.25 * kilometersPerMonth;
                }
                else if (kilometersPerMonth <= 20000)
                {
                    salary = 1.45 * kilometersPerMonth;
                }
            }
            salary *= 4;
            salary -= 0.1 * salary;

            Console.WriteLine($"{salary:f2}");
        }
    }
}
