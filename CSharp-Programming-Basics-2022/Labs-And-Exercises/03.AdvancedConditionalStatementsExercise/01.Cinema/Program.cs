using System;

namespace _01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cinemaType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int seats = rows * cols;
            double totalIncome = 0;

            if (cinemaType == "Premiere")
            {
                totalIncome = seats * 12;
            }
            else if (cinemaType == "Normal")
            {
                totalIncome = seats * 7.5;
            }
            else if (cinemaType == "Discount")
            {
                totalIncome = seats * 5;
            }

            Console.WriteLine($"{totalIncome:f2} leva");
        }
    }
}
