using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
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

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < countOfElementsToAdd; i++)
            {
                stack.Push(elementsToAdd[i]);
            }

            for (int i = 0; i < countOfElementsToRemove; i++)
            {
                stack.Pop();
            }

            Console.WriteLine(stack.Contains(elementToLookFor)
                ? "true"
                : stack.Count > 0
                    ? $"{stack.Min()}"
                    : "0");
        }
    }
}
