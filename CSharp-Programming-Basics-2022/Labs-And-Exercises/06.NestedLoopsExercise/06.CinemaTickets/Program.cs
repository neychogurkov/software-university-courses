using System;

namespace _06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            int studentTickets = 0;
            int standardTickets = 0;
            int kidTickets = 0;

            while (filmName != "Finish")
            {
                int startingFreeSeats = int.Parse(Console.ReadLine());
                int freeSeats = startingFreeSeats;
                int filmTickets = 0;

                while (freeSeats > 0)
                {
                    string ticketType = Console.ReadLine();

                    if (ticketType == "End")
                    {
                        break;
                    }

                    filmTickets++;
                    freeSeats--;

                    if (ticketType == "student")
                    {
                        studentTickets++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardTickets++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidTickets++;
                    }
                }

                double filmAttendance = (double)filmTickets / startingFreeSeats * 100;
                Console.WriteLine($"{filmName} - {filmAttendance:f2}% full.");

                filmName = Console.ReadLine();
            }

            double totalTickets = studentTickets + standardTickets + kidTickets;
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{studentTickets/totalTickets*100:f2}% student tickets.");
            Console.WriteLine($"{standardTickets/totalTickets*100:f2}% standard tickets.");
            Console.WriteLine($"{kidTickets/totalTickets*100:f2}% kids tickets.");
        }
    }
}
