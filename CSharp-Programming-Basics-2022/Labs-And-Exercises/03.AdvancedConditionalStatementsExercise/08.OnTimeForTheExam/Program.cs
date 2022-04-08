using System;

namespace _08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());
            int examTime = examHour * 60 + examMinutes;
            int arrivalTime = arrivalHour * 60 + arrivalMinutes;
            int timeDiff = examTime - arrivalTime;

            if (timeDiff <= 30 && timeDiff > 0)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{timeDiff} minutes before the start");
            }
            else if (timeDiff==0)
            {
                Console.WriteLine("On time");
            }
            else if (timeDiff > 30)
            {
                Console.WriteLine("Early");
                if (timeDiff > 59)
                {
                    int hours = timeDiff / 60;
                    int minutes = timeDiff % 60;
                    Console.WriteLine($"{hours}:{minutes:d2} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{timeDiff} minutes before the start");
                }
            }
            else
            {
                Console.WriteLine("Late");
                if (Math.Abs(timeDiff) > 59)
                {
                    int hours = Math.Abs(timeDiff) / 60;
                    int minutes = Math.Abs(timeDiff) % 60;
                    Console.WriteLine($"{hours}:{minutes:d2} hours after the start");
                }
                else
                {
                    Console.WriteLine($"{Math.Abs(timeDiff)} minutes after the start");
                }
            }
        }
    }
}
