using System;

namespace _06.WeddingSeats
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rowsInFirstSector = int.Parse(Console.ReadLine());
            int oddRowsSeats = int.Parse(Console.ReadLine());
            int evenRowsSeats = oddRowsSeats + 2;
            int seats = 0;

            for (char i = 'A'; i <= lastSector; i++)
            {
                for (int j = 1; j <= rowsInFirstSector; j++)
                {
                    if (j % 2 == 0)
                    {
                        for (char k = 'a'; k < 'a' + evenRowsSeats; k++)
                        {
                            Console.WriteLine($"{i}{j}{k}");
                            seats++;
                        }
                    }
                    else
                    {
                        for (char k = 'a'; k < 'a' + oddRowsSeats; k++)
                        {
                            Console.WriteLine($"{i}{j}{k}");
                            seats++;
                        }
                    }
                }
                rowsInFirstSector++;
            }

            Console.WriteLine(seats);
        }
    }
}
