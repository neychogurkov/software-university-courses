using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>(clothesValues);

            int racksCount = 1;
            int sum = 0;

            while (stack.Count > 0)
            {
                if (sum + stack.Peek() < rackCapacity)
                {
                    sum += stack.Pop();
                }
                else if (sum + stack.Peek() == rackCapacity)
                {
                    stack.Pop();
                    sum = 0;

                    if (stack.Count > 0)
                    {
                        racksCount++;
                    }
                }
                else
                {
                    racksCount++;
                    sum = 0;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
