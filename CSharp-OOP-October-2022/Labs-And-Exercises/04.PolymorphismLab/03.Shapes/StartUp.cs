namespace Shapes
{
using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Type?");
                string type = Console.ReadLine();

                Shape shape = null;
                try
                {
                    if (type == "Rectangle")
                    {
                        double height = double.Parse(Console.ReadLine());
                        double width = double.Parse(Console.ReadLine());
                        shape = new Rectangle(height, width);
                    }
                    else if (type == "Circle")
                    {
                        double radius = double.Parse(Console.ReadLine());
                        shape = new Circle(radius);
                    }
                    else
                    {
                        break;
                    }

                    Console.WriteLine("Area:" + shape.CalculateArea());
                    Console.WriteLine("Perimeter:" + shape.CalculatePerimeter());
                    Console.WriteLine(shape.Draw());
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
