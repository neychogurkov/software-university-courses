using System;

namespace _01.TennisEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tennisRacquetPrice = double.Parse(Console.ReadLine());
            int tennisRacquets = int.Parse(Console.ReadLine());
            int sneakers = int.Parse(Console.ReadLine());

            double totalPrice = tennisRacquetPrice * tennisRacquets + (double)sneakers * 1 / 6 * tennisRacquetPrice;
            totalPrice += 0.2 * totalPrice;

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(totalPrice * 1 / 8)}");
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(totalPrice * 7 / 8)}");
        }
    }
}
