using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01.Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int taskToKill = int.Parse(Console.ReadLine());

            while (true)
            {
                int currentTask = tasks.Peek();
                int currentThread = threads.Peek();

                if (currentTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {taskToKill}");
                    Console.WriteLine(string.Join(' ', threads));
                    return;
                }

                threads.Dequeue();

                if (currentThread >= currentTask)
                {
                    tasks.Pop();
                }
            }
        }
    }
}
