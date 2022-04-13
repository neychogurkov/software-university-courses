using System;

namespace _02.SleepyTomCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int holidays = int.Parse(Console.ReadLine());
            int workingDays = 365 - holidays;
            int playTime = workingDays * 63 + holidays * 127;
            int diff = Math.Abs(30000 - playTime);
            int hours = diff / 60;
            int minutes = diff % 60;

            if (playTime > 30000)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well"); 
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }
        }
    }
}
