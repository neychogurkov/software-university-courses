using System;

namespace _03.Gymnastics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string instrument = Console.ReadLine();
            double difficulty = 0;
            double performance = 0;

            if (country == "Russia")
            {
                if (instrument == "ribbon")
                {
                    difficulty = 9.1;
                    performance = 9.4;
                }
                else if (instrument == "hoop")
                {
                    difficulty = 9.3;
                    performance = 9.8;
                }
                else if (instrument == "rope")
                {
                    difficulty = 9.6;
                    performance = 9;
                }
            }
            else if (country == "Bulgaria")
            {
                if (instrument == "ribbon")
                {
                    difficulty = 9.6;
                    performance = 9.4;
                }
                else if (instrument == "hoop")
                {
                    difficulty = 9.55;
                    performance = 9.75;
                }
                else if (instrument == "rope")
                {
                    difficulty = 9.5;
                    performance = 9.4;
                }
            }
            else if (country == "Italy")
            {
                if (instrument == "ribbon")
                {
                    difficulty = 9.2;
                    performance = 9.5;
                }
                else if (instrument == "hoop")
                {
                    difficulty = 9.45;
                    performance = 9.35;
                }
                else if (instrument == "rope")
                {
                    difficulty = 9.7;
                    performance = 9.15;
                }
            }

            double totalRating = difficulty + performance;

            Console.WriteLine($"The team of {country} get {totalRating:f3} on {instrument}.");
            Console.WriteLine($"{(20-totalRating)/20*100:f2}%");
        }
    }
}
