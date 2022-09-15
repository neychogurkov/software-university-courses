using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int totalCarsPassed = 0;

            string car = Console.ReadLine();

            while (car != "END")
            {
                if (car == "green")
                {
                    int timeLeft = greenLightDuration;

                    while (cars.Count > 0 && timeLeft > cars.Peek().Length)
                    {
                        totalCarsPassed++;
                        timeLeft -= cars.Dequeue().Length;
                    }

                    if (cars.Count == 0)
                    {
                        car = Console.ReadLine();
                        continue;
                    }

                    timeLeft += freeWindowDuration;

                    if (timeLeft >= cars.Peek().Length)
                    {
                        totalCarsPassed++;
                        cars.Dequeue();
                    }
                    else
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{cars.Peek()} was hit at {cars.Peek()[timeLeft]}.");
                        return;
                    }
                }
                else
                {
                    cars.Enqueue(car);
                }

                car = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
