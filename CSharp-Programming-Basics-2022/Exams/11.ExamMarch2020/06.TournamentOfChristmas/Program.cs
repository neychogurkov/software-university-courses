using System;

namespace _06.TournamentOfChristmas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int winningDays = 0;
            int losingDays = 0;
            double totalMoneyWon = 0;

            for (int i = 0; i < days; i++)
            {
                string sport = Console.ReadLine();
                int wins = 0;
                int losses = 0;
                double moneyWonToday = 0;

                while (sport != "Finish")
                {
                    string result = Console.ReadLine();
                    if (result == "win")
                    {
                        wins++;
                        moneyWonToday += 20;
                    }
                    else if (result == "lose")
                    {
                        losses++;
                    }

                    sport = Console.ReadLine();
                }

                if (wins > losses)
                {
                    winningDays++;
                    moneyWonToday += 0.1 * moneyWonToday;
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
