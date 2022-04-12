using System;

namespace _04.Balls
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int balls = int.Parse(Console.ReadLine());
            double points = 0;
            int redBalls = 0;
            int orangeBalls = 0;
            int yellowBalls = 0;
            int whiteBalls = 0;
            int blackBalls = 0;
            int otherBalls = 0;

            for (int i = 0; i < balls; i++)
            {
                string color = Console.ReadLine();

                if (color == "red")
                {
                    points += 5;
                    redBalls++;
                }
                else if (color == "orange")
                {
                    points += 10;
                    orangeBalls++;
                }
                else if (color == "yellow")
                {
                    points += 15;
                    yellowBalls++;
                }
                else if (color == "white")
                {
                    points += 20;
                    whiteBalls++;
                }
                else if (color == "black")
                {
                    points = Math.Floor(points / 2);
                    blackBalls++;
                }
                else
                {
                    otherBalls++;
                }
            }

            Console.WriteLine($"Total points: {points}");
            Console.WriteLine($"Red balls: {redBalls}");
            Console.WriteLine($"Orange balls: {orangeBalls}");
            Console.WriteLine($"Yellow balls: {yellowBalls}");
            Console.WriteLine($"White balls: {whiteBalls}");
            Console.WriteLine($"Other colors picked: {otherBalls}");
            Console.WriteLine($"Divides from black balls: {blackBalls}");
        }
    }
}
