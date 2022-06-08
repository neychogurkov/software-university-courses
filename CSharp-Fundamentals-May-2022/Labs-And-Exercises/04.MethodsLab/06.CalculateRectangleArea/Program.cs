using System;

namespace _06.CalculateRectangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            Console.WriteLine(CalculateAreaOfRectangle(width, height));
        }

        static int CalculateAreaOfRectangle(int width, int height)
        {
            return width * height;
        }
    }
}
