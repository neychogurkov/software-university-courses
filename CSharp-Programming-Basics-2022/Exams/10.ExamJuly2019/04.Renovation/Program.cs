using System;

namespace _04.Renovation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine()) / 100;
            string command = Console.ReadLine();

            double areaToPaint = height * width * 4;
            areaToPaint -= Math.Ceiling(areaToPaint * percentage);

            while (command != "Tired!")
            {
                int paintLiters = int.Parse(command);
                areaToPaint -= paintLiters;
                if (areaToPaint <= 0)
                {
                    if (areaToPaint<0)
                    {
                        Console.WriteLine($"All walls are painted and you have {Math.Abs(areaToPaint)} l paint left!");
                    }
                    else
                    {
                        Console.WriteLine("All walls are painted! Great job, Pesho!");
                    }

                    return;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{areaToPaint} quadratic m left.");
        }
    }
}
