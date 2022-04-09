using System;

namespace _06.TournamentOfChristmas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalMoneyWon = 0;
            int winningDays = 0;
            int losingDays = 0;
            
            for (int i = 0; i < days; i++)
            {
                double moneyWonToday = 0;
                string sport = Console.ReadLine();
                int winsToday = 0;
                int lossesToday = 0;

                while (sport != "Finish")
                {
                    string result = Console.ReadLine();
                    if (result == "win")
                    {
                        moneyWonToday += 20;
                        winsToday++;
                    }
                    else if (result == "lose")
                    {
                        lossesToday++;
                    }

                    sport = Console.ReadLine();
                }

                if (winsToday > lossesToday)
                {
                    moneyWonToday += moneyWonToday * 0.1;
                    winningDays++;
                }
                else
                {
                    losingDays++;
                }
                totalMoneyWon += moneyWonToday;
            }

            if (winningDays > losingDays)
            {
                totalMoneyWon += 0.2 * totalMoneyWon;
                Console.WriteLine($"You won the tournament! Total raised money: {totalMoneyWon:f2}");
            }
            else
            {
                Console.WriteLine($"You lost the tournament! Total raised money: {totalMoneyWon:f2}");
            }
        }
    }
}
