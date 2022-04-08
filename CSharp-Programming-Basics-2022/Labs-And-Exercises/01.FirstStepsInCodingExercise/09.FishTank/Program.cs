using System;

namespace _09.FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine())/100;
            double volume = length * width * height * 0.001;
            double litersNeeded = volume - volume * percentage;
            Console.WriteLine(litersNeeded);
        }
    }
}
