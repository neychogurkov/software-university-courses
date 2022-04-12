using System;

namespace _02.TriangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = side * height / 2;

            Console.WriteLine($"{area:f2}");
        }
    }
}
