using System;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsNumbers = new HashSet<string>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(", ");

                if (command[0] == "END")
                {
                    break;
                }

                string direction = command[0];
                string carNumber = command[1];

                if (direction == "IN")
                {
                    carsNumbers.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    carsNumbers.Remove(carNumber);
                }
            }

            if (carsNumbers.Count > 0)
            {
                foreach (var carNumber in carsNumbers)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
