using System;

namespace _07.SchoolCamp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int overnights = int.Parse(Console.ReadLine());
            double price = 0;
            string sport = string.Empty;

            if (groupType == "boys")
            {
                if (season == "Spring")
                {
                    price = 7.2;
                    sport = "Tennis";
                }
                else if (season == "Summer")
                {
                    price = 15;
                    sport = "Football";
                }
                else if (season == "Winter")
                {
                    price = 9.6;
                    sport = "Judo";
                }
            }
            else if (groupType == "girls")
            {
                if (season == "Spring")
                {
                    price = 7.2;
                    sport = "Athletics";
                }
                else if (season == "Summer")
                {
                    price = 15;
                    sport = "Volleyball";
                }
                else if (season == "Winter")
                {
                    price = 9.6;
                    sport = "Gymnastics";
                }
            }
            else if (groupType == "mixed")
            {
                if (season == "Spring")
                {
                    price = 9.5;
                    sport = "Cycling";
                }
                else if (season == "Summer")
                {
                    price = 20;
                    sport = "Swimming";
                }
                else if (season == "Winter")
                {
                    price = 10;
                    sport = "Ski";
                }
            }

            price = price * students * overnights;
            if (students >= 50)
            {
                price /= 2;
            }
            else if (students >= 20)
            {
                price -= 0.15 * price;
            }
            else if (students >= 10)
            {
                price -= 0.05 * price;
            }

            Console.WriteLine($"{sport} {price:f2} lv.");
        }
    }
}
