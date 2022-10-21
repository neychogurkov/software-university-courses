using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootboxItems = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> secondLootboxItems = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int claimedItemsValue = 0;

            while (firstLootboxItems.Any() && secondLootboxItems.Any())
            {
                int sum = firstLootboxItems.Peek() + secondLootboxItems.Peek();

                if (sum % 2 == 0)
                {
                    claimedItemsValue += sum;
                    firstLootboxItems.Dequeue();
                    secondLootboxItems.Pop();
                }
                else
                {
                    firstLootboxItems.Enqueue(secondLootboxItems.Pop());
                }
            }

            Console.WriteLine((secondLootboxItems.Any() ? "First" : "Second") + " lootbox is empty");
            Console.WriteLine($"Your loot was {(claimedItemsValue >= 100 ? "epic!" : "poor...")} Value: {claimedItemsValue}");
        }
    }
}
