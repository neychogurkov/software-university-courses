using System;

namespace _01.SumSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstRacer = int.Parse(Console.ReadLine());
            int secondRacer = int.Parse(Console.ReadLine());
            int thirdRacer = int.Parse(Console.ReadLine());
            int secondsSum = firstRacer + secondRacer + thirdRacer;
            int minutes = secondsSum / 60;
            int seconds = secondsSum % 60;
            Console.WriteLine($"{minutes}:{seconds:d2}");
        }
    }
}
