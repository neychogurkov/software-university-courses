using System;

namespace _02.MovieDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int timeAvailable = int.Parse(Console.ReadLine());
            int scenes = int.Parse(Console.ReadLine());
            int sceneDuration = int.Parse(Console.ReadLine());
            double preparation = 0.15 * timeAvailable;
            double timeNeeded = sceneDuration * scenes + preparation;
            double timeDiff = Math.Abs(timeAvailable - timeNeeded);

            if (timeNeeded <= timeAvailable)
            {
                Console.WriteLine($"You managed to finish the movie on time! You have {Math.Round(timeDiff)} minutes left!");
            }
            else
            {
                Console.WriteLine($"Time is up! To complete the movie you need {Math.Round(timeDiff)} minutes.");
            }
        }
    }
}
