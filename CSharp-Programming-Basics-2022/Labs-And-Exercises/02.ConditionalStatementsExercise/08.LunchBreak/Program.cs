using System;

namespace _08.LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string series = Console.ReadLine();
            int episodeDuration = int.Parse(Console.ReadLine());
            double breakDuration = double.Parse(Console.ReadLine());
            double lunch = 0.125 * breakDuration;
            double rest = 0.25 * breakDuration;
            breakDuration -= lunch;
            breakDuration -= rest;
            double diff = Math.Ceiling(Math.Abs(episodeDuration - breakDuration));
            if (breakDuration >= episodeDuration)
            {
                Console.WriteLine($"You have enough time to watch {series} and left with {diff} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {series}, you need {diff} more minutes.");
            }
        }
    }
}
