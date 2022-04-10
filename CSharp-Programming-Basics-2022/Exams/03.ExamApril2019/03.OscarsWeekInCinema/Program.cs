using System;

namespace _03.OscarsWeekInCinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            string hallType = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());
            double income = 0;

            switch (filmName)
            {
                case "A Star Is Born":
                    if (hallType == "normal")
                    {
                        income = 7.5;
                    }
                    else if (hallType == "luxury")
                    {
                        income = 10.5;
                    }
                    else if (hallType == "ultra luxury")
                    {
                        income = 13.5;
                    }
                    break;
                case "Bohemian Rhapsody":
                    if (hallType == "normal")
                    {
                        income = 7.35;
                    }
                    else if (hallType == "luxury")
                    {
                        income = 9.45;
                    }
                    else if (hallType == "ultra luxury")
                    {
                        income = 12.75;
                    }
                    break;
                case "Green Book":
                    if (hallType == "normal")
                    {
                        income = 8.15;
                    }
                    else if (hallType == "luxury")
                    {
                        income = 10.25;
                    }
                    else if (hallType == "ultra luxury")
                    {
                        income = 13.25;
                    }
                    break;
                case "The Favourite":
                    if (hallType == "normal")
                    {
                        income = 8.75;
                    }
                    else if (hallType == "luxury")
                    {
                        income = 11.55;
                    }
                    else if (hallType == "ultra luxury")
                    {
                        income = 13.95;
                    }
                    break;
            }

            income *= tickets;

            Console.WriteLine($"{filmName} -> {income:f2} lv.");
        }
    }
}
