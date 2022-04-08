using System;

namespace _07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;
            switch (figure)
            {
                case "square":
                    {
                        double side = double.Parse(Console.ReadLine());
                        area = side * side;
                        break;
                    }
                case "rectangle":
                    {
                        double width = double.Parse(Console.ReadLine());
                        double height = double.Parse(Console.ReadLine());
                        area = width * height;
                        break;
                    }
                case "circle":
                    {
                        double radius = double.Parse(Console.ReadLine());
                        area = radius * radius * Math.PI;
                        break;
                    }
                case "triangle":
                    {
                        double side = double.Parse(Console.ReadLine());
                        double height = double.Parse(Console.ReadLine());
                        area = side * height / 2;
                        break;
                    }
            }
            Console.WriteLine($"{area:f3}");
        }
    }
}
