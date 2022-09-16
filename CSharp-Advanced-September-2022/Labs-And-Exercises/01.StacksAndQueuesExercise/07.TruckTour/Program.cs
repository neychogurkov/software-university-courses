using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());

            Queue<Pump> pumps = new Queue<Pump>();

            GetPumpsData(pumpsCount, pumps);

            int startIndex = 0;

            while (true)
            {
                if (IsTourCompleted(pumps))
                {
                    break;
                }

                startIndex++;
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(startIndex);
        }

        static void GetPumpsData(int pumpsCount, Queue<Pump> pumps)
        {
            for (int i = 0; i < pumpsCount; i++)
            {
                int[] pumpInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

                Pump pump = new Pump
                {
                    FuelAmount = pumpInfo[0],
                    Distance = pumpInfo[1]
                };

                pumps.Enqueue(pump);
            }
        }

        static bool IsTourCompleted(Queue<Pump> pumps)
        {
            bool isCompleted = true;
            int totalFuel = 0;

            for (int i = 0; i < pumps.Count; i++)
            {
                totalFuel += pumps.Peek().FuelAmount;

                if (totalFuel < pumps.Peek().Distance)
                {
                    isCompleted = false;
                }
                else
                {
                    totalFuel -= pumps.Peek().Distance;
                }

                pumps.Enqueue(pumps.Dequeue());
            }

            return isCompleted;
        }
    }

    class Pump
    {
        public int FuelAmount { get; set; }
        public int Distance { get; set; }
    }
}
