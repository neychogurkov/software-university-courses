using System;

namespace _04.VacationBooksList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int totalTime = pages / pagesPerHour;
            int hoursPerDay = totalTime / days;
            Console.WriteLine(hoursPerDay);
        }
    }
}
