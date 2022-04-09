using System;

namespace _04.PCGameShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double hearthstonePercentage = 0;
            double fornitePercentage = 0;
            double overwatchPercentage = 0;
            double othersPercentage = 0;

            for (int i = 0; i < n; i++)
            {
                string game = Console.ReadLine();
                if (game == "Hearthstone")
                {
                    hearthstonePercentage++;
                }
                else if (game == "Fornite")
                {
                    fornitePercentage++;
                }
                else if (game == "Overwatch")
                {
                    overwatchPercentage++;
                }
                else
                {
                    othersPercentage++;
                }
            }

            hearthstonePercentage = hearthstonePercentage / n * 100;
            fornitePercentage = fornitePercentage / n * 100;
            overwatchPercentage = overwatchPercentage / n * 100;
            othersPercentage = othersPercentage / n * 100;

            Console.WriteLine($"Hearthstone - {hearthstonePercentage:f2}%");
            Console.WriteLine($"Fornite - {fornitePercentage:f2}%");
            Console.WriteLine($"Overwatch - {overwatchPercentage:f2}%");
            Console.WriteLine($"Others - {othersPercentage:f2}%");
        }
    }
}
