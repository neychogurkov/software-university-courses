using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");

            Queue<string> songsQueue = new Queue<string>(songs);

            while (songsQueue.Count > 0)
            {
                string command = Console.ReadLine();

                ExecuteCommands(command, songsQueue);
            }

            Console.WriteLine("No more songs!");
        }

        static void ExecuteCommands(string command, Queue<string> songsQueue)
        {
            if (command == "Play")
            {
                songsQueue.Dequeue();
            }
            else if (command == "Show")
            {
                Console.WriteLine(string.Join(", ", songsQueue));
            }
            else if (command.StartsWith("Add"))
            {
                string song = command.Substring(4);

                if (songsQueue.Contains(song))
                {
                    Console.WriteLine($"{song} is already contained!");
                }
                else
                {
                    songsQueue.Enqueue(song);
                }
            }
        }
    }
}
