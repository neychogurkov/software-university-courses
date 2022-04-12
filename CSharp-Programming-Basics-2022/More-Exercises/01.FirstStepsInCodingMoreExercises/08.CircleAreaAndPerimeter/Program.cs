using System;

namespace _08.CircleAreaAndPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());
            double area = radius * radius * Math.PI;
            double perimeter = 2 * Math.PI * radius;

            Console.WriteLine($"{area:f2}");
            Console.WriteLine($"{perimeter:f2}");
        }
    }
}
