using System;
using System.Collections;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>();

            string command = Console.ReadLine();

            int carsCount = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        carsCount++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{carsCount} cars passed the crossroads.");
        }
    }
}
