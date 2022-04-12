using System;

namespace _05.TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine()) * 100;
            double h = double.Parse(Console.ReadLine()) * 100;
            h -= 100;

            double workPlaces = Math.Floor(h / 70);
            workPlaces *= Math.Floor(w / 120);
            workPlaces -= 3;

            Console.WriteLine(workPlaces);
        }
    }
}
