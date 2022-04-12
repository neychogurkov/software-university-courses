using System;

namespace _07.HousePainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            double frontWallArea = x * x - 1.2 * 2;
            double backWallArea = x * x;
            double sideWallArea = x * y - 1.5 * 1.5;
            double totalWallsArea = frontWallArea + backWallArea + 2 * sideWallArea;
            double roofArea = 2 * x * y + 2 * (x * h / 2);
            double greenPaintNeeded = totalWallsArea / 3.4;
            double redPaintNeeded = roofArea / 4.3;

            Console.WriteLine($"{greenPaintNeeded:f2}");
            Console.WriteLine($"{redPaintNeeded:f2}");
        }
    }
}
