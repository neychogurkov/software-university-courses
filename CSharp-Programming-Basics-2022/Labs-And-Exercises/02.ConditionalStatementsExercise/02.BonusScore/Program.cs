using System;

namespace _02.BonusScore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialPoints = int.Parse(Console.ReadLine());
            double bonusPoints = 0;
            if (initialPoints <= 100)
            {
                bonusPoints += 5;
            }
            else if (initialPoints > 100 && initialPoints <= 1000)
            {
                bonusPoints = 0.2 * initialPoints;
            }
            else
            {
                bonusPoints = 0.1 * initialPoints;
            }
            if (initialPoints % 2 == 0)
            {
                bonusPoints += 1;
            }
            else if (initialPoints % 5 == 0)
            {
                bonusPoints += 2;
            }
            double totalPoints = initialPoints + bonusPoints;
            Console.WriteLine(bonusPoints);
            Console.WriteLine(totalPoints);
        }
    }
}
