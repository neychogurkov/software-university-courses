using System;

namespace _03.Time_15Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            if (minutes >= 45)
            {
                if (hour == 23)
                {
                    hour = 0;
                }
                else
                {
                    hour++;
                }
                minutes = 15 - (60 - minutes);
            }
            else
            {
                minutes += 15;
            }
            Console.WriteLine($"{hour}:{minutes:d2}");
        }
    }
}
