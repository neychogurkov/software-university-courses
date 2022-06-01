using System;

namespace _01.DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] daysNames = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int numberOfDay = int.Parse(Console.ReadLine());

            Console.WriteLine(numberOfDay > 0 && numberOfDay < 8 ? daysNames[numberOfDay - 1] : "Invalid day!");
        }
    }
}
