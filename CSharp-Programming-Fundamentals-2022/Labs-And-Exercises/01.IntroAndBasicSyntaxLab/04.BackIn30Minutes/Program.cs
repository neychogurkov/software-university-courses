using System;

namespace _04.BackIn30Minutes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int totalTime = hours * 60 + minutes + 30;
            if (hours == 23&&minutes>=30)
            {
                hours = 0;
            }
            else hours = totalTime / 60;
            minutes = totalTime % 60;

            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
