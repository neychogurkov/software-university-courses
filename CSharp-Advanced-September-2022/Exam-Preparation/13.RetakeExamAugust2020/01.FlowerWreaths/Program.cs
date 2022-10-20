using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> lillies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            int wreathsMade = 0;
            int flowersLeft = 0;

            while (roses.Any() && lillies.Any())
            {
                int currentRose = roses.Peek();
                int currentLily = lillies.Pop();
                int sum = currentRose + currentLily;

                if (sum == 15)
                {
                    wreathsMade++;
                    roses.Dequeue();
                }
                else if (sum > 15)
                {
                    lillies.Push(currentLily - 2);
                }
                else
                {
                    flowersLeft += sum;
                    roses.Dequeue();
                }
            }

            wreathsMade += flowersLeft / 15;

            Console.WriteLine(wreathsMade >= 5
                ? $"You made it, you are going to the competition with {wreathsMade} wreaths!"
                : $"You didn't make it, you need {5 - wreathsMade} wreaths more!");
        }
    }
}
