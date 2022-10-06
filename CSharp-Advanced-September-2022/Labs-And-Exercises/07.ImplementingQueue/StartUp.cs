using System;

namespace ImplementingQueue
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue();

            queue.Enqueue(5);
            queue.Enqueue(3);
            queue.Enqueue(7);
            queue.Enqueue(2);
            queue.Enqueue(8);

            Console.Write("Queue:");
            queue.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());

            Console.Write("Queue:");
            queue.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            Console.WriteLine($"Count: {queue.Count}");
            queue.Clear();
            Console.WriteLine($"Count: {queue.Count}");

        }
    }
}
