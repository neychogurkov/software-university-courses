using System;

namespace _05.EasterEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int paintedEggs = int.Parse(Console.ReadLine());
            int redEggs = 0;
            int orangeEggs = 0;
            int blueEggs = 0;
            int greenEggs = 0;

            for (int i = 0; i < paintedEggs; i++)
            {
                string color = Console.ReadLine();
                if (color == "red")
                {
                    redEggs++;
                }
                else if (color == "orange")
                {
                    orangeEggs++;
                }
                else if (color == "blue")
                {
                    blueEggs++;
                }
                else if (color == "green")
                {
                    greenEggs++;
                }
            }

            Console.WriteLine($"Red eggs: {redEggs}");
            Console.WriteLine($"Orange eggs: {orangeEggs}");
            Console.WriteLine($"Blue eggs: {blueEggs}");
            Console.WriteLine($"Green eggs: {greenEggs}");

            if (redEggs >= orangeEggs && redEggs >= blueEggs && redEggs >= greenEggs)
            {
                Console.WriteLine($"Max eggs: {redEggs} -> red");
            }
            else if (orangeEggs >= redEggs && orangeEggs >= blueEggs && orangeEggs >= greenEggs)
            {
                Console.WriteLine($"Max eggs: {orangeEggs} -> orange");
            }
            else if (blueEggs >= redEggs && blueEggs >= orangeEggs && blueEggs >= greenEggs)
            {
                Console.WriteLine($"Max eggs: {blueEggs} -> blue");
            }
            else if (greenEggs >= redEggs && greenEggs >= orangeEggs && greenEggs >= blueEggs)
            {
                Console.WriteLine($"Max eggs: {greenEggs} -> green");
            }

        }
    }
}
