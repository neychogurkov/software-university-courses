using System;

namespace _05.PCGameShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gamesSold = int.Parse(Console.ReadLine());
            double hearthstonePercentage = 0;
            double fornitePercentage = 0;
            double overwatchPercentage = 0;
            double othersPercentage = 0;

            for (int i = 0; i < gamesSold; i++)
            {
                string gameName = Console.ReadLine();

                if (gameName == "Hearthstone")
                {
                    hearthstonePercentage++;
                }
                else if (gameName == "Fornite")
                {
                    fornitePercentage++;
                }
                else if (gameName == "Overwatch")
                {
                    overwatchPercentage++;
                }
                else                {
                    othersPercentage++;
                }
            }

            hearthstonePercentage = hearthstonePercentage / gamesSold * 100;
            fornitePercentage = fornitePercentage / gamesSold * 100;
            overwatchPercentage = overwatchPercentage / gamesSold * 100;
            othersPercentage = othersPercentage / gamesSold * 100;

            Console.WriteLine($"Hearthstone - {hearthstonePercentage:f2}%");
            Console.WriteLine($"Fornite - {fornitePercentage:f2}%");
            Console.WriteLine($"Overwatch - {overwatchPercentage:f2}%");
            Console.WriteLine($"Others - {othersPercentage:f2}%");
        }
    }
}
