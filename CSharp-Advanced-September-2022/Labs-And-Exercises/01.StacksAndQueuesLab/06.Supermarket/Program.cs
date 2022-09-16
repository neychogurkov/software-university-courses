using System;
using System.Collections;
using System.Collections.Generic;

namespace _06.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customersQueue = new Queue<string>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "Paid")
                {
                    while (customersQueue.Count>0)
                    {
                        Console.WriteLine(customersQueue.Dequeue());
                    }
                }
                else
                {
                    customersQueue.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{customersQueue.Count} people remaining.");
        }
    }
}
