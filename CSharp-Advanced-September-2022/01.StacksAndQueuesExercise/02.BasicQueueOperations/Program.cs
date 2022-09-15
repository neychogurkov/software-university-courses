using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int countOfElementsToAdd = input[0];
            int countOfElementsToRemove = input[1];
            int elementToLookFor = input[2];
            int[] elementsToAdd = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < countOfElementsToAdd; i++)
            {
                queue.Enqueue(elementsToAdd[i]);
            }

            for (int i = 0; i < countOfElementsToRemove; i++)
            {
                queue.Dequeue();
            }

            Console.WriteLine(queue.Contains(elementToLookFor)
                ? "true"
                : queue.Count > 0
                    ? $"{queue.Min()}"
                    : "0");
        }
    }
}
